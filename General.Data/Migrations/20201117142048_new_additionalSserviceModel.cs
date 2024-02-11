using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class new_additionalSserviceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromSqr",
                table: "KsPrices");

            migrationBuilder.DropColumn(
                name: "ToSqr",
                table: "KsPrices");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfWindowSides",
                table: "KsPrices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionType",
                table: "KsPrices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WindowType",
                table: "KsPrices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "KsAdditionalServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KsAdditionalServices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KsAdditionalServices");

            migrationBuilder.DropColumn(
                name: "NumberOfWindowSides",
                table: "KsPrices");

            migrationBuilder.DropColumn(
                name: "SubscriptionType",
                table: "KsPrices");

            migrationBuilder.DropColumn(
                name: "WindowType",
                table: "KsPrices");

            migrationBuilder.AddColumn<int>(
                name: "FromSqr",
                table: "KsPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToSqr",
                table: "KsPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
