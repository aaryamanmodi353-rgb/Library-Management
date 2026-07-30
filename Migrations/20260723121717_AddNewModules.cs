using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddNewModules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Librarians",
                columns: table => new
                {
                    LibrarianId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Librarians", x => x.LibrarianId);
                });

            migrationBuilder.CreateTable(
                name: "logintab",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    username = table.Column<string>(type: "TEXT", nullable: true),
                    password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logintab", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Student_Name = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Phone_Number = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.InsertData(
                table: "Librarians",
                columns: new[] { "LibrarianId", "Age", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, 34, "Sarah Connor", "555-0201" },
                    { 2, 28, "John Doe", "555-0202" },
                    { 3, 45, "Michael Scott", "555-0203" },
                    { 4, 39, "Ellen Ripley", "555-0204" },
                    { 5, 40, "James Bond", "555-0205" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Email", "Phone_Number", "Student_Name" },
                values: new object[,]
                {
                    { 1, "alice.j@email.com", "555-0101", "Alice Johnson" },
                    { 2, "bob.smith@email.com", "555-0102", "Bob Smith" },
                    { 3, "charlie.b@email.com", "555-0103", "Charlie Brown" },
                    { 4, "diana.p@email.com", "555-0104", "Diana Prince" },
                    { 5, "evan.w@email.com", "555-0105", "Evan Wright" }
                });

            migrationBuilder.InsertData(
                table: "logintab",
                columns: new[] { "id", "password", "username" },
                values: new object[,]
                {
                    { 1, "12345", "admin" },
                    { 2, "myc546", "mycodingproject" },
                    { 3, "myc", "my" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Librarians");

            migrationBuilder.DropTable(
                name: "logintab");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
