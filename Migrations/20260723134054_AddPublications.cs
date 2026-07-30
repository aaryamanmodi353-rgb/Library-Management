using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddPublications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Magazines");

            migrationBuilder.DropTable(
                name: "Newspapers");

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Publisher = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "Id", "IsAvailable", "PublishedDate", "Publisher", "Title", "Type" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Global Media Group", "The Daily Times", 0 },
                    { 2, true, new DateTime(2026, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "WallSt Press", "Financial Chronicle", 0 },
                    { 3, true, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Silicon Valley Pubs", "Tech Weekly News", 0 },
                    { 4, true, new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "City Press House", "Metro Morning Post", 0 },
                    { 5, false, new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Global Media Group", "Saturday Sports Herald", 0 },
                    { 6, true, new DateTime(2026, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NatGeo Society", "National Geographic Vol 45", 1 },
                    { 7, true, new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Condé Nast", "Vogue Fashion Summer", 1 },
                    { 8, false, new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forbes Media", "Forbes Business 30 Under 30", 1 },
                    { 9, true, new DateTime(2026, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Future US", "PC Gamer Ultimate", 1 },
                    { 10, true, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Springer Nature", "Scientific American", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.CreateTable(
                name: "Magazines",
                columns: table => new
                {
                    MagazineId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    IssueNumber = table.Column<string>(type: "TEXT", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Publisher = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magazines", x => x.MagazineId);
                });

            migrationBuilder.CreateTable(
                name: "Newspapers",
                columns: table => new
                {
                    NewspaperId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Publisher = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newspapers", x => x.NewspaperId);
                });

            migrationBuilder.InsertData(
                table: "Magazines",
                columns: new[] { "MagazineId", "Description", "ImageUrl", "IssueNumber", "PublishedDate", "Publisher", "Title" },
                values: new object[,]
                {
                    { 1, "A magazine focusing on modern technology, AI, and future trends.", "https://images.unsplash.com/photo-1550751827-4bd374c3f58b?w=500&auto=format&fit=crop&q=60", "104", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Future Media", "Tech Today" },
                    { 2, "Explore the beautiful natural world with our weekly nature deep dives.", "https://images.unsplash.com/photo-1469474968028-56623f02e42e?w=500&auto=format&fit=crop&q=60", "Vol 45", new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Green Earth Publishing", "Nature Weekly" },
                    { 3, "The premier source for sports news, athletic profiles, and game summaries.", "https://images.unsplash.com/photo-1541534741688-6078c6bfb5c5?w=500&auto=format&fit=crop&q=60", "Issue 9", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Athletic Press", "Sports Illustrated" }
                });

            migrationBuilder.InsertData(
                table: "Newspapers",
                columns: new[] { "NewspaperId", "Name", "PublishedDate", "Publisher" },
                values: new object[,]
                {
                    { 1, "The Daily Chronicle", new DateTime(2023, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Global News Network" },
                    { 2, "Morning Herald", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "City Press" }
                });
        }
    }
}
