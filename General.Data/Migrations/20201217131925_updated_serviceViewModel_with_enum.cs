using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class updated_serviceViewModel_with_enum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "KsServices");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "KsServices");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "KsCustomer_Order_Services");

            migrationBuilder.AddColumn<int>(
                name: "MainServiceType",
                table: "KsServices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MainServiceType",
                table: "KsCustomer_Order_Services",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainServiceType",
                table: "KsServices");

            migrationBuilder.DropColumn(
                name: "MainServiceType",
                table: "KsCustomer_Order_Services");

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "KsServices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "KsServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "KsCustomer_Order_Services",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
