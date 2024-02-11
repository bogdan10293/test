using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class wip_new_additionalModel_n_price_updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasePriceCorporate",
                table: "KsPrices");

            migrationBuilder.DropColumn(
                name: "BasePricePrivate",
                table: "KsPrices");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "KsPrices",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "KsPrices",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "VAT",
                table: "KsPrices",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "KsAdditionalServices",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "KsAdditionalServices",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "Rut",
                table: "KsAdditionalServices",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "KsPrices");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "KsPrices");

            migrationBuilder.DropColumn(
                name: "VAT",
                table: "KsPrices");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "KsAdditionalServices");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "KsAdditionalServices");

            migrationBuilder.DropColumn(
                name: "Rut",
                table: "KsAdditionalServices");

            migrationBuilder.AddColumn<int>(
                name: "BasePriceCorporate",
                table: "KsPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BasePricePrivate",
                table: "KsPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
