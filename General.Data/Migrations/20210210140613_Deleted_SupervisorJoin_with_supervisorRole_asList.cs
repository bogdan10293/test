using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class Deleted_SupervisorJoin_with_supervisorRole_asList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KsSupervisorRoles_KsSupervisor_Projects_KsSupervisorProjectJoinKsProjectId_KsSupervisorProjectJoinKsSupervisorId",
                table: "KsSupervisorRoles");

            migrationBuilder.DropIndex(
                name: "IX_KsSupervisorRoles_KsSupervisorProjectJoinKsProjectId_KsSupervisorProjectJoinKsSupervisorId",
                table: "KsSupervisorRoles");

            migrationBuilder.DropColumn(
                name: "KsSupervisorProjectJoinKsProjectId",
                table: "KsSupervisorRoles");

            migrationBuilder.DropColumn(
                name: "KsSupervisorProjectJoinKsSupervisorId",
                table: "KsSupervisorRoles");

            migrationBuilder.AddColumn<string>(
                name: "SupervisorRole",
                table: "KsSupervisor_Projects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupervisorRole",
                table: "KsSupervisor_Projects");

            migrationBuilder.AddColumn<int>(
                name: "KsSupervisorProjectJoinKsProjectId",
                table: "KsSupervisorRoles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KsSupervisorProjectJoinKsSupervisorId",
                table: "KsSupervisorRoles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KsSupervisorRoles_KsSupervisorProjectJoinKsProjectId_KsSupervisorProjectJoinKsSupervisorId",
                table: "KsSupervisorRoles",
                columns: new[] { "KsSupervisorProjectJoinKsProjectId", "KsSupervisorProjectJoinKsSupervisorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_KsSupervisorRoles_KsSupervisor_Projects_KsSupervisorProjectJoinKsProjectId_KsSupervisorProjectJoinKsSupervisorId",
                table: "KsSupervisorRoles",
                columns: new[] { "KsSupervisorProjectJoinKsProjectId", "KsSupervisorProjectJoinKsSupervisorId" },
                principalTable: "KsSupervisor_Projects",
                principalColumns: new[] { "KsProjectId", "KsSupervisorId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
