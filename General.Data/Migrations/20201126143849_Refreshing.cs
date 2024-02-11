using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class Refreshing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Orders_Customers_CustomerFK",
                table: "Customer_Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_KsOrderServiceAdditionalEntity_Service_AdditionalServices_OrderServiceFK",
                table: "KsOrderServiceAdditionalEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_AdditionalServices_Customer_Orders_OrderFK",
                table: "Service_AdditionalServices");

            migrationBuilder.DropTable(
                name: "KsPrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service_AdditionalServices",
                table: "Service_AdditionalServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KsOrderServiceAdditionalEntity",
                table: "KsOrderServiceAdditionalEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer_Orders",
                table: "Customer_Orders");

            migrationBuilder.RenameTable(
                name: "Service_AdditionalServices",
                newName: "KsCustomer_Order_Services");

            migrationBuilder.RenameTable(
                name: "KsOrderServiceAdditionalEntity",
                newName: "KsCustomer_Order_Service_Additionals");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "KsCustomers");

            migrationBuilder.RenameTable(
                name: "Customer_Orders",
                newName: "KsCustomer_Orders");

            migrationBuilder.RenameIndex(
                name: "IX_Service_AdditionalServices_OrderFK",
                table: "KsCustomer_Order_Services",
                newName: "IX_KsCustomer_Order_Services_OrderFK");

            migrationBuilder.RenameIndex(
                name: "IX_KsOrderServiceAdditionalEntity_OrderServiceFK",
                table: "KsCustomer_Order_Service_Additionals",
                newName: "IX_KsCustomer_Order_Service_Additionals_OrderServiceFK");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_Orders_CustomerFK",
                table: "KsCustomer_Orders",
                newName: "IX_KsCustomer_Orders_CustomerFK");

            migrationBuilder.AddColumn<int>(
                name: "ServiceFk",
                table: "KsAdditionalServices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KsCustomer_Order_Services",
                table: "KsCustomer_Order_Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KsCustomer_Order_Service_Additionals",
                table: "KsCustomer_Order_Service_Additionals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KsCustomers",
                table: "KsCustomers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KsCustomer_Orders",
                table: "KsCustomer_Orders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_KsAdditionalServices_ServiceFk",
                table: "KsAdditionalServices",
                column: "ServiceFk");

            migrationBuilder.AddForeignKey(
                name: "FK_KsAdditionalServices_KsServices_ServiceFk",
                table: "KsAdditionalServices",
                column: "ServiceFk",
                principalTable: "KsServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KsCustomer_Order_Service_Additionals_KsCustomer_Order_Services_OrderServiceFK",
                table: "KsCustomer_Order_Service_Additionals",
                column: "OrderServiceFK",
                principalTable: "KsCustomer_Order_Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KsCustomer_Order_Services_KsCustomer_Orders_OrderFK",
                table: "KsCustomer_Order_Services",
                column: "OrderFK",
                principalTable: "KsCustomer_Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KsCustomer_Orders_KsCustomers_CustomerFK",
                table: "KsCustomer_Orders",
                column: "CustomerFK",
                principalTable: "KsCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KsAdditionalServices_KsServices_ServiceFk",
                table: "KsAdditionalServices");

            migrationBuilder.DropForeignKey(
                name: "FK_KsCustomer_Order_Service_Additionals_KsCustomer_Order_Services_OrderServiceFK",
                table: "KsCustomer_Order_Service_Additionals");

            migrationBuilder.DropForeignKey(
                name: "FK_KsCustomer_Order_Services_KsCustomer_Orders_OrderFK",
                table: "KsCustomer_Order_Services");

            migrationBuilder.DropForeignKey(
                name: "FK_KsCustomer_Orders_KsCustomers_CustomerFK",
                table: "KsCustomer_Orders");

            migrationBuilder.DropIndex(
                name: "IX_KsAdditionalServices_ServiceFk",
                table: "KsAdditionalServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KsCustomers",
                table: "KsCustomers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KsCustomer_Orders",
                table: "KsCustomer_Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KsCustomer_Order_Services",
                table: "KsCustomer_Order_Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KsCustomer_Order_Service_Additionals",
                table: "KsCustomer_Order_Service_Additionals");

            migrationBuilder.DropColumn(
                name: "ServiceFk",
                table: "KsAdditionalServices");

            migrationBuilder.RenameTable(
                name: "KsCustomers",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "KsCustomer_Orders",
                newName: "Customer_Orders");

            migrationBuilder.RenameTable(
                name: "KsCustomer_Order_Services",
                newName: "Service_AdditionalServices");

            migrationBuilder.RenameTable(
                name: "KsCustomer_Order_Service_Additionals",
                newName: "KsOrderServiceAdditionalEntity");

            migrationBuilder.RenameIndex(
                name: "IX_KsCustomer_Orders_CustomerFK",
                table: "Customer_Orders",
                newName: "IX_Customer_Orders_CustomerFK");

            migrationBuilder.RenameIndex(
                name: "IX_KsCustomer_Order_Services_OrderFK",
                table: "Service_AdditionalServices",
                newName: "IX_Service_AdditionalServices_OrderFK");

            migrationBuilder.RenameIndex(
                name: "IX_KsCustomer_Order_Service_Additionals_OrderServiceFK",
                table: "KsOrderServiceAdditionalEntity",
                newName: "IX_KsOrderServiceAdditionalEntity_OrderServiceFK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer_Orders",
                table: "Customer_Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service_AdditionalServices",
                table: "Service_AdditionalServices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KsOrderServiceAdditionalEntity",
                table: "KsOrderServiceAdditionalEntity",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "KsPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    NumberOfWindowSides = table.Column<int>(type: "int", nullable: false),
                    OccuranceType = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    SubscriptionType = table.Column<int>(type: "int", nullable: false),
                    VAT = table.Column<double>(type: "float", nullable: false),
                    WeekDay = table.Column<int>(type: "int", nullable: false),
                    WindowType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KsPrices", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Orders_Customers_CustomerFK",
                table: "Customer_Orders",
                column: "CustomerFK",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KsOrderServiceAdditionalEntity_Service_AdditionalServices_OrderServiceFK",
                table: "KsOrderServiceAdditionalEntity",
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
