using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant_Pick.Migrations
{
    public partial class UserRestaurantRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddedById",
                table: "Restaurants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_AddedById",
                table: "Restaurants",
                column: "AddedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Users_AddedById",
                table: "Restaurants",
                column: "AddedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Users_AddedById",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_AddedById",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "Restaurants");
        }
    }
}
