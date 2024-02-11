using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class added_ks_order_windwo_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KsCustomer_Order_Service_WindowTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    NumberOfWindowSides = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    OrderServiceFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KsCustomer_Order_Service_WindowTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KsCustomer_Order_Service_WindowTypes_KsCustomer_Order_Services_OrderServiceFK",
                        column: x => x.OrderServiceFK,
                        principalTable: "KsCustomer_Order_Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KsCustomer_Order_Service_WindowTypes_OrderServiceFK",
                table: "KsCustomer_Order_Service_WindowTypes",
                column: "OrderServiceFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KsCustomer_Order_Service_WindowTypes");
        }
    }
}
