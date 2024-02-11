using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class Update_DepartmentViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carpenting",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Gardening",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "GeneralCleaning",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "HotelCleaning",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Installation",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "MovingCleaning",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "OfficeCleaning",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Painting",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "StairCleaning",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "StoreCleaning",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "WindowCleaning",
                table: "Departments");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Departments",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Departments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Departments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Departments");

            migrationBuilder.AddColumn<string>(
                name: "Carpenting",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gardening",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GeneralCleaning",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HotelCleaning",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Installation",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MovingCleaning",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfficeCleaning",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Painting",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StairCleaning",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreCleaning",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WindowCleaning",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
