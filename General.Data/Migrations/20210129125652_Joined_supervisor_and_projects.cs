using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class Joined_supervisor_and_projects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KsSuperVisors",
                table: "KsSuperVisors");

            migrationBuilder.RenameTable(
                name: "KsSuperVisors",
                newName: "KsSupervisors");

            migrationBuilder.RenameColumn(
                name: "SuperVisorId",
                table: "KsSupervisors",
                newName: "SupervisorId");

            migrationBuilder.AddColumn<int>(
                name: "KsSupervisorFK",
                table: "KsEmployees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KsSupervisorId",
                table: "KsEmployees",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KsSupervisors",
                table: "KsSupervisors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "KsSupervisor_Projects",
                columns: table => new
                {
                    KsSupervisorId = table.Column<int>(nullable: false),
                    KsProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KsSupervisor_Projects", x => new { x.KsProjectId, x.KsSupervisorId });
                    table.ForeignKey(
                        name: "FK_KsSupervisor_Projects_KsProjects_KsProjectId",
                        column: x => x.KsProjectId,
                        principalTable: "KsProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KsSupervisor_Projects_KsSupervisors_KsSupervisorId",
                        column: x => x.KsSupervisorId,
                        principalTable: "KsSupervisors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KsEmployees_KsSupervisorId",
                table: "KsEmployees",
                column: "KsSupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_KsSupervisor_Projects_KsSupervisorId",
                table: "KsSupervisor_Projects",
                column: "KsSupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_KsEmployees_KsSupervisors_KsSupervisorId",
                table: "KsEmployees",
                column: "KsSupervisorId",
                principalTable: "KsSupervisors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KsEmployees_KsSupervisors_KsSupervisorId",
                table: "KsEmployees");

            migrationBuilder.DropTable(
                name: "KsSupervisor_Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KsSupervisors",
                table: "KsSupervisors");

            migrationBuilder.DropIndex(
                name: "IX_KsEmployees_KsSupervisorId",
                table: "KsEmployees");

            migrationBuilder.DropColumn(
                name: "KsSupervisorFK",
                table: "KsEmployees");

            migrationBuilder.DropColumn(
                name: "KsSupervisorId",
                table: "KsEmployees");

            migrationBuilder.RenameTable(
                name: "KsSupervisors",
                newName: "KsSuperVisors");

            migrationBuilder.RenameColumn(
                name: "SupervisorId",
                table: "KsSuperVisors",
                newName: "SuperVisorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KsSuperVisors",
                table: "KsSuperVisors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmploymentDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }
    }
}
