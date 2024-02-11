using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class added_dbConfiguration_for_customer_order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderServices_Orders_OrderId",
                table: "OrderServices");

            migrationBuilder.DropIndex(
                name: "IX_OrderServices_OrderId",
                table: "OrderServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderServices");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order_services");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer_orders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_services",
                table: "Order_services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer_orders",
                table: "Customer_orders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderServices_OrderFK",
                table: "OrderServices",
                column: "OrderFK");

            migrationBuilder.CreateIndex(
                name: "IX_Order_services_CustomerFK",
                table: "Order_services",
                column: "CustomerFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_services_Customer_orders_CustomerFK",
                table: "Order_services",
                column: "CustomerFK",
                principalTable: "Customer_orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServices_Order_services_OrderFK",
                table: "OrderServices",
                column: "OrderFK",
                principalTable: "Order_services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_services_Customer_orders_CustomerFK",
                table: "Order_services");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderServices_Order_services_OrderFK",
                table: "OrderServices");

            migrationBuilder.DropIndex(
                name: "IX_OrderServices_OrderFK",
                table: "OrderServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_services",
                table: "Order_services");

            migrationBuilder.DropIndex(
                name: "IX_Order_services_CustomerFK",
                table: "Order_services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer_orders",
                table: "Customer_orders");

            migrationBuilder.RenameTable(
                name: "Order_services",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Customer_orders",
                newName: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderServices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderServices_OrderId",
                table: "OrderServices",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServices_Orders_OrderId",
                table: "OrderServices",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
