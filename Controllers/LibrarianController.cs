using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace LibraryManagement.Controllers
{
    public class LibrarianController : Controller
    {
        private readonly IConfiguration _config;

        public LibrarianController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index(string? searchTerm, int page = 1)
        {
            if (page < 1) page = 1;
            int pageSize = 5; // Change this number to control items per page
            int offset = (page - 1) * pageSize;

            var librarians = new List<LibrarianModel>();
            int totalRecords = 0;

            using var con = new SqliteConnection(_config.GetConnectionString("DefaultConnection"));
            con.Open();

            // 1. Get Total Count for Pagination Links
            string countQuery = "SELECT COUNT(*) FROM Librarians WHERE (@SearchTerm IS NULL OR Name LIKE '%' || @SearchTerm || '%')";
            using (var countCmd = new SqliteCommand(countQuery, con))
            {
                countCmd.Parameters.AddWithValue("@SearchTerm", (object?)searchTerm ?? DBNull.Value);
                totalRecords = Convert.ToInt32(countCmd.ExecuteScalar());
            }

            // 2. Fetch Filtered and Paginated Records
            string dataQuery = @"SELECT * FROM Librarians 
                                 WHERE (@SearchTerm IS NULL OR Name LIKE '%' || @SearchTerm || '%')
                                 ORDER BY LibrarianId 
                                 LIMIT @PageSize OFFSET @Offset";
            
            using (var cmd = new SqliteCommand(dataQuery, con))
            {
                cmd.Parameters.AddWithValue("@SearchTerm", (object?)searchTerm ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Offset", offset);
                cmd.Parameters.AddWithValue("@PageSize", pageSize);
                
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    librarians.Add(new LibrarianModel
                    {
                        LibrarianId = Convert.ToInt32(reader["LibrarianId"]),
                        Name = reader["Name"].ToString(),
                        Age = Convert.ToInt32(reader["Age"]),
                        Phone = reader["Phone"].ToString()
                    });
                }
            }

            // 3. Populate and return View Model
            var viewModel = new LibrarianIndexViewModel
            {
                Librarians = librarians,
                SearchTerm = searchTerm,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize)
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LibrarianModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using var con = new SqliteConnection(_config.GetConnectionString("DefaultConnection"));
            var cmd = new SqliteCommand("INSERT INTO Librarians (Name, Age, Phone) VALUES (@Name, @Age, @Phone)", con);
            cmd.Parameters.AddWithValue("@Name", model.Name);
            cmd.Parameters.AddWithValue("@Age", model.Age);
            cmd.Parameters.AddWithValue("@Phone", model.Phone);
            con.Open();
            cmd.ExecuteNonQuery();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            LibrarianModel librarian = new();
            using var con = new SqliteConnection(_config.GetConnectionString("DefaultConnection"));
            var cmd = new SqliteCommand("SELECT * FROM Librarians WHERE LibrarianId=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                librarian.LibrarianId = Convert.ToInt32(reader["LibrarianId"]);
                librarian.Name = reader["Name"].ToString();
                librarian.Age = Convert.ToInt32(reader["Age"]);
                librarian.Phone = reader["Phone"].ToString();
            }
            return View(librarian);
        }

        [HttpPost]
        public IActionResult Edit(LibrarianModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using var con = new SqliteConnection(_config.GetConnectionString("DefaultConnection"));
            var cmd = new SqliteCommand("UPDATE Librarians SET Name=@Name, Age=@Age, Phone=@Phone WHERE LibrarianId=@id", con);
            cmd.Parameters.AddWithValue("@Name", model.Name);
            cmd.Parameters.AddWithValue("@Age", model.Age);
            cmd.Parameters.AddWithValue("@Phone", model.Phone);
            cmd.Parameters.AddWithValue("@id", model.LibrarianId);
            con.Open();
            cmd.ExecuteNonQuery();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            using var con = new SqliteConnection(_config.GetConnectionString("DefaultConnection"));
            var cmd = new SqliteCommand("DELETE FROM Librarians WHERE LibrarianId=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            cmd.ExecuteNonQuery();

            return RedirectToAction("Index");
        }
    }
}
