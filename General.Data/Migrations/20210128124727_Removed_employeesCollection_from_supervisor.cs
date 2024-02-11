using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class Removed_employeesCollection_from_supervisor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KsEmployees_KsSuperVisors_KsSupervisorViewModelId",
                table: "KsEmployees");

            migrationBuilder.DropIndex(
                name: "IX_KsEmployees_KsSupervisorViewModelId",
                table: "KsEmployees");

            migrationBuilder.DropColumn(
                name: "KsSupervisorViewModelId",
                table: "KsEmployees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KsSupervisorViewModelId",
                table: "KsEmployees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KsEmployees_KsSupervisorViewModelId",
                table: "KsEmployees",
                column: "KsSupervisorViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_KsEmployees_KsSuperVisors_KsSupervisorViewModelId",
                table: "KsEmployees",
                column: "KsSupervisorViewModelId",
                principalTable: "KsSuperVisors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
