using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddMagazines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Magazines",
                columns: table => new
                {
                    MagazineId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Publisher = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IssueNumber = table.Column<string>(type: "TEXT", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magazines", x => x.MagazineId);
                });

            migrationBuilder.InsertData(
                table: "Magazines",
                columns: new[] { "MagazineId", "IssueNumber", "PublishedDate", "Publisher", "Title" },
                values: new object[,]
                {
                    { 1, "104", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Future Media", "Tech Today" },
                    { 2, "Vol 45", new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Green Earth Publishing", "Nature Weekly" },
                    { 3, "Issue 9", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Athletic Press", "Sports Illustrated" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Magazines");
        }
    }
}
