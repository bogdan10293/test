using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class updating_projectmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkAddress",
                table: "KsProjects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkAddressZipCode",
                table: "KsProjects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkAddress",
                table: "KsProjects");

            migrationBuilder.DropColumn(
                name: "WorkAddressZipCode",
                table: "KsProjects");
        }
    }
}
