using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class added_KswindowTypeMOdel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KsWindowTypeViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    NumberOfWindowSides = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: true),
                    ServiceFk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KsWindowTypeViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KsWindowTypeViewModel_KsServices_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "KsServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KsWindowTypeViewModel_ServiceId",
                table: "KsWindowTypeViewModel",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KsWindowTypeViewModel");
        }
    }
}
