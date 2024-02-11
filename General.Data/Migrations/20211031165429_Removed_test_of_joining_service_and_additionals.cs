using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class Removed_test_of_joining_service_and_additionals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KsService_Additionals");

            migrationBuilder.DropColumn(
                name: "AdditionalServiceFK",
                table: "KsServices");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KsAdditionalServices_KsServices_ServiceFk",
                table: "KsAdditionalServices");

            migrationBuilder.DropIndex(
                name: "IX_KsAdditionalServices_ServiceFk",
                table: "KsAdditionalServices");

            migrationBuilder.AddColumn<int>(
                name: "AdditionalServiceFK",
                table: "KsServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "KsService_Additionals",
                columns: table => new
                {
                    KsAdditionalServiceId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KsService_Additionals", x => new { x.KsAdditionalServiceId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_KsService_Additionals_KsAdditionalServices_KsAdditionalServiceId",
                        column: x => x.KsAdditionalServiceId,
                        principalTable: "KsAdditionalServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KsService_Additionals_KsServices_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "KsServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KsService_Additionals_ServiceId",
                table: "KsService_Additionals",
                column: "ServiceId");
        }
    }
}
