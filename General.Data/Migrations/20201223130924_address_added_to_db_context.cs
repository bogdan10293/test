using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class address_added_to_db_context : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KsAddressViewModel_KsCustomers_KsCustomerFk",
                table: "KsAddressViewModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KsAddressViewModel",
                table: "KsAddressViewModel");

            migrationBuilder.RenameTable(
                name: "KsAddressViewModel",
                newName: "KsCustomerAddress");

            migrationBuilder.RenameIndex(
                name: "IX_KsAddressViewModel_KsCustomerFk",
                table: "KsCustomerAddress",
                newName: "IX_KsCustomerAddress_KsCustomerFk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KsCustomerAddress",
                table: "KsCustomerAddress",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KsCustomerAddress_KsCustomers_KsCustomerFk",
                table: "KsCustomerAddress",
                column: "KsCustomerFk",
                principalTable: "KsCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KsCustomerAddress_KsCustomers_KsCustomerFk",
                table: "KsCustomerAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KsCustomerAddress",
                table: "KsCustomerAddress");

            migrationBuilder.RenameTable(
                name: "KsCustomerAddress",
                newName: "KsAddressViewModel");

            migrationBuilder.RenameIndex(
                name: "IX_KsCustomerAddress_KsCustomerFk",
                table: "KsAddressViewModel",
                newName: "IX_KsAddressViewModel_KsCustomerFk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KsAddressViewModel",
                table: "KsAddressViewModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KsAddressViewModel_KsCustomers_KsCustomerFk",
                table: "KsAddressViewModel",
                column: "KsCustomerFk",
                principalTable: "KsCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
