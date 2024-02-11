using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class update_of_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KsWindowTypeViewModel_KsServices_ServiceId",
                table: "KsWindowTypeViewModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KsWindowTypeViewModel",
                table: "KsWindowTypeViewModel");

            migrationBuilder.DropIndex(
                name: "IX_KsWindowTypeViewModel_ServiceId",
                table: "KsWindowTypeViewModel");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "KsWindowTypeViewModel");

            migrationBuilder.RenameTable(
                name: "KsWindowTypeViewModel",
                newName: "KsWindowTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KsWindowTypes",
                table: "KsWindowTypes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_KsWindowTypes_ServiceFk",
                table: "KsWindowTypes",
                column: "ServiceFk");

            migrationBuilder.AddForeignKey(
                name: "FK_KsWindowTypes_KsServices_ServiceFk",
                table: "KsWindowTypes",
                column: "ServiceFk",
                principalTable: "KsServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KsWindowTypes_KsServices_ServiceFk",
                table: "KsWindowTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KsWindowTypes",
                table: "KsWindowTypes");

            migrationBuilder.DropIndex(
                name: "IX_KsWindowTypes_ServiceFk",
                table: "KsWindowTypes");

            migrationBuilder.RenameTable(
                name: "KsWindowTypes",
                newName: "KsWindowTypeViewModel");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "KsWindowTypeViewModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KsWindowTypeViewModel",
                table: "KsWindowTypeViewModel",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_KsWindowTypeViewModel_ServiceId",
                table: "KsWindowTypeViewModel",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_KsWindowTypeViewModel_KsServices_ServiceId",
                table: "KsWindowTypeViewModel",
                column: "ServiceId",
                principalTable: "KsServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
