using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantApp.DAL.Migrations
{
    public partial class confadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_FoodCategories_FoodCategoryId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_FoodCategoryId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodCategoryId",
                table: "Foods");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                table: "Foods",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Foods",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "FoodCategories",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_CategoryId",
                table: "Foods",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodCategories_CategoryId",
                table: "Foods",
                column: "CategoryId",
                principalTable: "FoodCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_FoodCategories_CategoryId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_CategoryId",
                table: "Foods");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.AddColumn<int>(
                name: "FoodCategoryId",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "FoodCategories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FoodCategoryId",
                table: "Foods",
                column: "FoodCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodCategories_FoodCategoryId",
                table: "Foods",
                column: "FoodCategoryId",
                principalTable: "FoodCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
