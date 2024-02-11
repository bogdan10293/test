using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class removed_testMember_in_serviceViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Customer_Orders_OrderId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_OrderId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "OrderFK",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Services");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderFK",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_OrderId",
                table: "Services",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Customer_Orders_OrderId",
                table: "Services",
                column: "OrderId",
                principalTable: "Customer_Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
