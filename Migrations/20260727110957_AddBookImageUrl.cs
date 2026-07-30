using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddBookImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Books12",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Books12",
                keyColumn: "BookId",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1544947950-fa07a98d237f?w=500&q=80");

            migrationBuilder.UpdateData(
                table: "Books12",
                keyColumn: "BookId",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1589829085413-56de8ae18c73?w=500&q=80");

            migrationBuilder.UpdateData(
                table: "Books12",
                keyColumn: "BookId",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1532012197267-da84d127e765?w=500&q=80");

            migrationBuilder.UpdateData(
                table: "Books12",
                keyColumn: "BookId",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1481627834876-b7833e8f5570?w=500&q=80");

            migrationBuilder.UpdateData(
                table: "Books12",
                keyColumn: "BookId",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1512820790803-83ca734da794?w=500&q=80");

            migrationBuilder.UpdateData(
                table: "Books12",
                keyColumn: "BookId",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1495446815901-a7297e633e8d?w=500&q=80");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Books12");
        }
    }
}
