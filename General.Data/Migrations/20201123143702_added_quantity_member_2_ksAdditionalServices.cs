using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class added_quantity_member_2_ksAdditionalServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "KsAdditionalServices",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "KsAdditionalServices");
        }
    }
}
