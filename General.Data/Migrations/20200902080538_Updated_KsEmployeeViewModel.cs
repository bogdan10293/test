using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class Updated_KsEmployeeViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "KsEmployees");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "KsEmployees");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "KsEmployees",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "KsEmployees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonalIdentityNumber",
                table: "KsEmployees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TangellaId",
                table: "KsEmployees",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "KsEmployees");

            migrationBuilder.DropColumn(
                name: "PersonalIdentityNumber",
                table: "KsEmployees");

            migrationBuilder.DropColumn(
                name: "TangellaId",
                table: "KsEmployees");

            migrationBuilder.AlterColumn<string>(
                name: "Updated",
                table: "KsEmployees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "KsEmployees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "KsEmployees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
