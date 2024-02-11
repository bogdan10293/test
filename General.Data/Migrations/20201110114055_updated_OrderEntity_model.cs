using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class updated_OrderEntity_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderFK",
                table: "Services",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Services",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Customer_Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "OrderDate",
                table: "Customer_Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
