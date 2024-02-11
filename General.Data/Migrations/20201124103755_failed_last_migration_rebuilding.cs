using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class failed_last_migration_rebuilding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KsAdditionalServices_Service_AdditionalServices_OrderServiceFK",
                table: "KsAdditionalServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_AdditionalServices_Customer_Orders_OrderFK",
                table: "Service_AdditionalServices");

            migrationBuilder.DropIndex(
                name: "IX_KsAdditionalServices_OrderServiceFK",
                table: "KsAdditionalServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service_AdditionalServices",
                table: "Service_AdditionalServices");

            migrationBuilder.DropColumn(
                name: "OrderServiceFK",
                table: "KsAdditionalServices");

            migrationBuilder.RenameTable(
                name: "Service_AdditionalServices",
                newName: "Customer_Order_Services");

            migrationBuilder.RenameIndex(
                name: "IX_Service_AdditionalServices_OrderFK",
                table: "Customer_Order_Services",
                newName: "IX_Customer_Order_Services_OrderFK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer_Order_Services",
                table: "Customer_Order_Services",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Order_Services_Customer_Orders_OrderFK",
                table: "Customer_Order_Services",
                column: "OrderFK",
                principalTable: "Customer_Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Order_Services_Customer_Orders_OrderFK",
                table: "Customer_Order_Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer_Order_Services",
                table: "Customer_Order_Services");

            migrationBuilder.RenameTable(
                name: "Customer_Order_Services",
                newName: "Service_AdditionalServices");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_Order_Services_OrderFK",
                table: "Service_AdditionalServices",
                newName: "IX_Service_AdditionalServices_OrderFK");

            migrationBuilder.AddColumn<int>(
                name: "OrderServiceFK",
                table: "KsAdditionalServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service_AdditionalServices",
                table: "Service_AdditionalServices",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_KsAdditionalServices_OrderServiceFK",
                table: "KsAdditionalServices",
                column: "OrderServiceFK");

            migrationBuilder.AddForeignKey(
                name: "FK_KsAdditionalServices_Service_AdditionalServices_OrderServiceFK",
                table: "KsAdditionalServices",
                column: "OrderServiceFK",
                principalTable: "Service_AdditionalServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_AdditionalServices_Customer_Orders_OrderFK",
                table: "Service_AdditionalServices",
                column: "OrderFK",
                principalTable: "Customer_Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
