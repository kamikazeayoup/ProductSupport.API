using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductSupport.API.Migrations
{
    /// <inheritdoc />
    public partial class AddPathColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagepath",
                table: "Companies",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagepath",
                table: "Companies");
        }
    }
}
