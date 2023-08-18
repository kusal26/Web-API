using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webapi1.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "available_seats",
                table: "ShowTiming",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "available_seats",
                table: "ShowTiming");
        }
    }
}
