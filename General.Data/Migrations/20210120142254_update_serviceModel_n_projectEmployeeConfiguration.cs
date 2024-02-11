using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class update_serviceModel_n_projectEmployeeConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KsEmployee_Projects",
                columns: table => new
                {
                    KsEmployeeId = table.Column<int>(nullable: false),
                    KsProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KsEmployee_Projects", x => new { x.KsEmployeeId, x.KsProjectId });
                    table.ForeignKey(
                        name: "FK_KsEmployee_Projects_KsProjects_KsEmployeeId",
                        column: x => x.KsEmployeeId,
                        principalTable: "KsProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KsEmployee_Projects_KsEmployees_KsProjectId",
                        column: x => x.KsProjectId,
                        principalTable: "KsEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KsEmployee_Projects_KsProjectId",
                table: "KsEmployee_Projects",
                column: "KsProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KsEmployee_Projects");
        }
    }
}
