using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMagazines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Magazines",
                type: "TEXT",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Magazines",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Magazines",
                keyColumn: "MagazineId",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "A magazine focusing on modern technology, AI, and future trends.", "https://images.unsplash.com/photo-1550751827-4bd374c3f58b?w=500&auto=format&fit=crop&q=60" });

            migrationBuilder.UpdateData(
                table: "Magazines",
                keyColumn: "MagazineId",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Explore the beautiful natural world with our weekly nature deep dives.", "https://images.unsplash.com/photo-1469474968028-56623f02e42e?w=500&auto=format&fit=crop&q=60" });

            migrationBuilder.UpdateData(
                table: "Magazines",
                keyColumn: "MagazineId",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "The premier source for sports news, athletic profiles, and game summaries.", "https://images.unsplash.com/photo-1541534741688-6078c6bfb5c5?w=500&auto=format&fit=crop&q=60" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Magazines");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Magazines");
        }
    }
}
