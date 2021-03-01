using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant_Pick.Migrations
{
    public partial class AddDateVisitedToRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateVisited",
                table: "Restaurants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateVisited",
                table: "Restaurants");
        }
    }
}
