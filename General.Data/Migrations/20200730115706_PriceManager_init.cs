using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class PriceManager_init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerType = table.Column<int>(nullable: false),
                    ServiceType = table.Column<int>(nullable: false),
                    OccuranceType = table.Column<int>(nullable: false),
                    WeekDay = table.Column<int>(nullable: false),
                    MinSqr = table.Column<int>(nullable: false),
                    MaxSqr = table.Column<int>(nullable: false),
                    PriceSqr = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");
        }
    }
}
