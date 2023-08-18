using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webapi1.Migrations
{
    /// <inheritdoc />
    public partial class addedshowdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Showdate",
                table: "BookedModels",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Showdate",
                table: "BookedModels");
        }
    }
}
