using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class added_members_2_ksServiceAddtionalOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service_AdditionalServices",
                table: "Service_AdditionalServices",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "KsOrderServiceAdditionalEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Rut = table.Column<bool>(nullable: false),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    OrderServiceFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KsOrderServiceAdditionalEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KsOrderServiceAdditionalEntity_Service_AdditionalServices_OrderServiceFK",
                        column: x => x.OrderServiceFK,
                        principalTable: "Service_AdditionalServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KsOrderServiceAdditionalEntity_OrderServiceFK",
                table: "KsOrderServiceAdditionalEntity",
                column: "OrderServiceFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_AdditionalServices_Customer_Orders_OrderFK",
                table: "Service_AdditionalServices",
                column: "OrderFK",
                principalTable: "Customer_Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_AdditionalServices_Customer_Orders_OrderFK",
                table: "Service_AdditionalServices");

            migrationBuilder.DropTable(
                name: "KsOrderServiceAdditionalEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service_AdditionalServices",
                table: "Service_AdditionalServices");

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
    }
}
