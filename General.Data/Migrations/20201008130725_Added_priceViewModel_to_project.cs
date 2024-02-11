using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class Added_priceViewModel_to_project : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KsPrices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OccuranceType = table.Column<int>(nullable: false),
                    FromSqr = table.Column<int>(nullable: false),
                    ToSqr = table.Column<int>(nullable: false),
                    WeekDay = table.Column<int>(nullable: false),
                    BasePricePrivate = table.Column<int>(nullable: false),
                    BasePriceCorporate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KsPrices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KsPrices");
        }
    }
}
