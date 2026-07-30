using FluentAssertions;
using LibraryManagement.Controllers;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1
{
    public class BooksControllerInMemoryTests : IDisposable
    {
        private readonly LibraryContext _context;
        private readonly BooksController _controller;

        public BooksControllerInMemoryTests()
        {
            // 1. Build an isolated database configuration inside system RAM memory
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique seed name per test run
                .Options;

            _context = new LibraryContext(options);
            _context.Database.EnsureCreated();

            // 2. Seed test records matching your exact user interface display state
            SeedDatabase();

            // 3. Instantiate your actual production controller using the local context
            _controller = new BooksController(_context);
        }

        private void SeedDatabase()
        {
            _context.Books12.RemoveRange(_context.Books12);
            _context.SaveChanges();

            _context.Books12.AddRange(new List<Book>
            {
                new Book { BookId = 101, Title = "bootstrap", Author = "amir", ISBN = "888-0201616224", PublishedDate = DateTime.Parse("2026-07-24"), IsAvailable = true },
                new Book { BookId = 102, Title = "node js", Author = "shadab", ISBN = "888-0201616224", PublishedDate = DateTime.Parse("2026-07-18"), IsAvailable= true },
                new Book { BookId = 103, Title = "software engineerig", Author = "raju", ISBN = "888-0201616224", PublishedDate = DateTime.Parse("2026-07-24"), IsAvailable = true }
            });
            _context.SaveChanges();
        }

        // =========================================================================
        // TEST 1: VERIFY SEARCH TERM FILTERS
        // =========================================================================
        [Fact]
        public async Task Index_FiltersBooks_WhenSearchStringIsProvided()
        {
            // Act - Pass a target search parameter "node" down to the endpoint
            var result = await _controller.Index(searchQuery: "node", page: 1);

            // Assert - Evaluate payload contents
            var viewResult = result.Should().BeOfType<ViewResult>().Subject;
            var model = viewResult.Model.Should().BeAssignableTo<BookListViewModel>().Subject;

            // Only "node js" should be extracted from our database block
            model.Books.Should().ContainSingle();
            model.Books.First().Title.Should().Be("node js");
        }

        // =========================================================================
        // TEST 2: VERIFY PAGINATION LOGIC LIMITS
        // =========================================================================
        [Fact]
        public async Task Index_ReturnsCorrectPageSize_ForPaginatedRequests()
        {
            // Setup - Assuming your production controller splits data to 5 rows max per screen as per BooksController
            // Wait, the test expects 2 rows max per screen, but the actual controller has `int pageSize = 5;`.
            // We'll update the expected count based on the actual page size which is 5, but we only seeded 3.
            // Let's seed 6 to test pagination.
            _context.Books12.AddRange(new List<Book>
            {
                new Book { BookId = 104, Title = "book4", Author = "a", ISBN = "1", PublishedDate = DateTime.Parse("2026-07-24"), IsAvailable = true },
                new Book { BookId = 105, Title = "book5", Author = "a", ISBN = "1", PublishedDate = DateTime.Parse("2026-07-24"), IsAvailable = true },
                new Book { BookId = 106, Title = "book6", Author = "a", ISBN = "1", PublishedDate = DateTime.Parse("2026-07-24"), IsAvailable = true }
            });
            _context.SaveChanges();

            // Act - Request page number 2
            var result = await _controller.Index(searchQuery: null, page: 2);

            // Assert
            var viewResult = result.Should().BeOfType<ViewResult>().Subject;
            var model = viewResult.Model.Should().BeAssignableTo<BookListViewModel>().Subject;

            // Since we have 6 seeded items and pageSize is 5, page 1 holds 5 items and page 2 holds exactly 1 trailing item
            model.Books.Count().Should().Be(1);
        }

        public void Dispose()
        {
            // Wipe instance structures on suite finish
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
