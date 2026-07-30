using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        // Seed initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Title = "The Pragmatic Programmer",
                    Author = "Andrew Hunt and David Thomas",
                    ISBN = "978-0201616224",
                    PublishedDate = new DateTime(2021, 10, 30),
                    IsAvailable = true,
                    ImageUrl = "https://images.unsplash.com/photo-1544947950-fa07a98d237f?w=500&q=80"
                },
                new Book
                {
                    BookId = 2,
                    Title = "Design Pattern using C#",
                    Author = "Robert C. Martin",
                    ISBN = "978-0132350884",
                    PublishedDate = new DateTime(2023, 8, 1),
                    IsAvailable = true,
                    ImageUrl = "https://images.unsplash.com/photo-1589829085413-56de8ae18c73?w=500&q=80"
                },
                new Book
                {
                    BookId = 3,
                    Title = "Mastering ASP.NET Core",
                    Author = "Pranaya Kumar Rout",
                    ISBN = "978-0451616235",
                    PublishedDate = new DateTime(2022, 11, 22),
                    IsAvailable = true,
                    ImageUrl = "https://images.unsplash.com/photo-1532012197267-da84d127e765?w=500&q=80"
                },
                new Book
                {
                    BookId = 4,
                    Title = "SQL Server with DBA",
                    Author = "Rakesh Kumat",
                    ISBN = "978-4562350123",
                    PublishedDate = new DateTime(2020, 8, 15),
                    IsAvailable = true,
                    ImageUrl = "https://images.unsplash.com/photo-1481627834876-b7833e8f5570?w=500&q=80"
                },
                new Book
                {
                    BookId = 5,
                    Title = "Clean Code",
                    Author = "Robert C. Martin",
                    ISBN = "978-0132350882",
                    PublishedDate = new DateTime(2008, 8, 1),
                    IsAvailable = true,
                    ImageUrl = "https://images.unsplash.com/photo-1512820790803-83ca734da794?w=500&q=80"
                },
                new Book
                {
                    BookId = 6,
                    Title = "Refactoring",
                    Author = "Martin Fowler",
                    ISBN = "978-0134757599",
                    PublishedDate = new DateTime(2018, 12, 31),
                    IsAvailable = true,
                    ImageUrl = "https://images.unsplash.com/photo-1495446815901-a7297e633e8d?w=500&q=80"
                }
            );

            // Configure LoginTabs
            modelBuilder.Entity<LoginModel>().ToTable("logintab");
            modelBuilder.Entity<LoginModel>().HasData(
                new LoginModel { id = 1, username = "admin", password = "12345" },
                new LoginModel { id = 2, username = "mycodingproject", password = "myc546" },
                new LoginModel { id = 3, username = "my", password = "myc" }
            );

            // Configure Librarians
            modelBuilder.Entity<LibrarianModel>().HasKey(l => l.LibrarianId);
            modelBuilder.Entity<LibrarianModel>().ToTable("Librarians");
            modelBuilder.Entity<LibrarianModel>().HasData(
                new LibrarianModel { LibrarianId = 1, Name = "Sarah Connor", Age = 34, Phone = "555-0201" },
                new LibrarianModel { LibrarianId = 2, Name = "John Doe", Age = 28, Phone = "555-0202" },
                new LibrarianModel { LibrarianId = 3, Name = "Michael Scott", Age = 45, Phone = "555-0203" },
                new LibrarianModel { LibrarianId = 4, Name = "Ellen Ripley", Age = 39, Phone = "555-0204" },
                new LibrarianModel { LibrarianId = 5, Name = "James Bond", Age = 40, Phone = "555-0205" }
            );

            // Configure Students
            // StudentName mapping to Student_Name
            modelBuilder.Entity<StudentModel>().HasKey(s => s.StudentId);
            modelBuilder.Entity<StudentModel>().ToTable("Students");
            modelBuilder.Entity<StudentModel>()
                .Property(s => s.StudentName)
                .HasColumnName("Student_Name");
            modelBuilder.Entity<StudentModel>()
                .Property(s => s.Phone)
                .HasColumnName("Phone_Number");

            modelBuilder.Entity<StudentModel>().HasData(
                new StudentModel { StudentId = 1, StudentName = "Alice Johnson", Email = "alice.j@email.com", Phone = "555-0101" },
                new StudentModel { StudentId = 2, StudentName = "Bob Smith", Email = "bob.smith@email.com", Phone = "555-0102" },
                new StudentModel { StudentId = 3, StudentName = "Charlie Brown", Email = "charlie.b@email.com", Phone = "555-0103" },
                new StudentModel { StudentId = 4, StudentName = "Diana Prince", Email = "diana.p@email.com", Phone = "555-0104" },
                new StudentModel { StudentId = 5, StudentName = "Evan Wright", Email = "evan.w@email.com", Phone = "555-0105" }
            );

            // Configure Publications (Unified Newspapers and Magazines)
            modelBuilder.Entity<Publication>().HasData(
                new Publication { Id = 1, Title = "The Daily Times", Publisher = "Global Media Group", PublishedDate = new DateTime(2026, 07, 22), Type = PublicationType.Newspaper, IsAvailable = true, ImageUrl = "https://images.unsplash.com/photo-1585829365295-ab7cd400c167?w=500&q=80" },
                new Publication { Id = 2, Title = "Financial Chronicle", Publisher = "WallSt Press", PublishedDate = new DateTime(2026, 07, 21), Type = PublicationType.Newspaper, IsAvailable = true, ImageUrl = "https://images.unsplash.com/photo-1546422904-90eab23c3d7e?w=500&q=80" },
                new Publication { Id = 3, Title = "Tech Weekly News", Publisher = "Silicon Valley Pubs", PublishedDate = new DateTime(2026, 07, 20), Type = PublicationType.Newspaper, IsAvailable = true, ImageUrl = "https://images.unsplash.com/photo-1504711434969-e33886168f5c?w=500&q=80" },
                new Publication { Id = 4, Title = "Metro Morning Post", Publisher = "City Press House", PublishedDate = new DateTime(2026, 07, 22), Type = PublicationType.Newspaper, IsAvailable = true, ImageUrl = "https://images.unsplash.com/photo-1526470608268-f674ce90ebd4?w=500&q=80" },
                new Publication { Id = 5, Title = "Saturday Sports Herald", Publisher = "Global Media Group", PublishedDate = new DateTime(2026, 07, 18), Type = PublicationType.Newspaper, IsAvailable = false, ImageUrl = "https://images.unsplash.com/photo-1550751827-4bd374c3f58b?w=500&q=80" },
                
                new Publication { Id = 6, Title = "National Geographic Vol 45", Publisher = "NatGeo Society", PublishedDate = new DateTime(2026, 07, 01), Type = PublicationType.Magazine, IsAvailable = true, ImageUrl = "https://images.unsplash.com/photo-1550751827-4bd374c3f58b?w=500&q=80" },
                new Publication { Id = 7, Title = "Vogue Fashion Summer", Publisher = "Condé Nast", PublishedDate = new DateTime(2026, 06, 15), Type = PublicationType.Magazine, IsAvailable = true, ImageUrl = "https://images.unsplash.com/photo-1469474968028-56623f02e42e?w=500&q=80" },
                new Publication { Id = 8, Title = "Forbes Business 30 Under 30", Publisher = "Forbes Media", PublishedDate = new DateTime(2026, 07, 10), Type = PublicationType.Magazine, IsAvailable = false, ImageUrl = "https://images.unsplash.com/photo-1559526324-4b87b5e36e44?w=500&q=80" },
                new Publication { Id = 9, Title = "PC Gamer Ultimate", Publisher = "Future US", PublishedDate = new DateTime(2026, 07, 05), Type = PublicationType.Magazine, IsAvailable = true, ImageUrl = "https://images.unsplash.com/photo-1511512578047-dfb367046420?w=500&q=80" },
                new Publication { Id = 10, Title = "Scientific American", Publisher = "Springer Nature", PublishedDate = new DateTime(2026, 06, 28), Type = PublicationType.Magazine, IsAvailable = true, ImageUrl = "https://images.unsplash.com/photo-1532012197267-da84d127e765?w=500&q=80" }
            );
        }

        public DbSet<Book> Books12 { get; set; }
        public DbSet<BorrowRecord> BorrowRecords12 { get; set; }
        public DbSet<LoginModel> LoginTabs { get; set; }
        public DbSet<LibrarianModel> Librarians { get; set; }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<Publication> Publications { get; set; }
    }
}
