using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class update_service_and_customermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "KsServices",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KsProjectViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    CustomerFk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KsProjectViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KsProjectViewModel_KsCustomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "KsCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KsProjectViewModel_CustomerId",
                table: "KsProjectViewModel",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KsProjectViewModel");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "KsServices");
        }
    }
}
