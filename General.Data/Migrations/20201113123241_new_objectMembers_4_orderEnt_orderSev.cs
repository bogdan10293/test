using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class new_objectMembers_4_orderEnt_orderSev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Customer_Orders");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Customer_Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Customer_Orders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Customer_Order_Services",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Customer_Order_Services");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Customer_Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
