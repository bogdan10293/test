using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class added_ProjecViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Projects_KsProjectViewModel_KsProjectId",
                table: "Customer_Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KsProjectViewModel",
                table: "KsProjectViewModel");

            migrationBuilder.RenameTable(
                name: "KsProjectViewModel",
                newName: "KsProjects");

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "KsProjects",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_KsProjects",
                table: "KsProjects",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Projects_KsProjects_KsProjectId",
                table: "Customer_Projects",
                column: "KsProjectId",
                principalTable: "KsProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Projects_KsProjects_KsProjectId",
                table: "Customer_Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KsProjects",
                table: "KsProjects");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "KsProjects");

            migrationBuilder.RenameTable(
                name: "KsProjects",
                newName: "KsProjectViewModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KsProjectViewModel",
                table: "KsProjectViewModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Projects_KsProjectViewModel_KsProjectId",
                table: "Customer_Projects",
                column: "KsProjectId",
                principalTable: "KsProjectViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
