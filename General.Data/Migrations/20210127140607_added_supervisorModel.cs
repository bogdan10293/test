using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class added_supervisorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KsSupervisorViewModelId",
                table: "KsEmployees",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KsSuperVisors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    SuperVisorId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KsSuperVisors", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KsEmployees_KsSuperVisors_KsSupervisorViewModelId",
                table: "KsEmployees");

            migrationBuilder.DropTable(
                name: "KsSuperVisors");

            migrationBuilder.DropIndex(
                name: "IX_KsEmployees_KsSupervisorViewModelId",
                table: "KsEmployees");

            migrationBuilder.DropColumn(
                name: "KsSupervisorViewModelId",
                table: "KsEmployees");
        }
    }
}
