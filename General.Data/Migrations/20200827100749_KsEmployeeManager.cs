using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class KsEmployeeManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WindowCleaning = table.Column<string>(nullable: true),
                    GeneralCleaning = table.Column<string>(nullable: true),
                    MovingCleaning = table.Column<string>(nullable: true),
                    OfficeCleaning = table.Column<string>(nullable: true),
                    HotelCleaning = table.Column<string>(nullable: true),
                    StoreCleaning = table.Column<string>(nullable: true),
                    StairCleaning = table.Column<string>(nullable: true),
                    Gardening = table.Column<string>(nullable: true),
                    Carpenting = table.Column<string>(nullable: true),
                    Painting = table.Column<string>(nullable: true),
                    Installation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KsEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Mail = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Updated = table.Column<string>(nullable: true),
                    SupervisorId = table.Column<int>(nullable: false),
                    RegionId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KsEmployees", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "KsEmployees");
        }
    }
}
