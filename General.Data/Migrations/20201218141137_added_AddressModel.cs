using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class added_AddressModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KsProjectViewModel_KsCustomers_CustomerId",
                table: "KsProjectViewModel");

            migrationBuilder.DropIndex(
                name: "IX_KsProjectViewModel_CustomerId",
                table: "KsProjectViewModel");

            migrationBuilder.DropColumn(
                name: "CustomerFk",
                table: "KsProjectViewModel");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "KsProjectViewModel");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "KsCustomers");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "KsCustomers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "KsCustomers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "KsCustomers");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "KsCustomers");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceType",
                table: "KsCustomers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KsCustomerEntityId",
                table: "Employee_services",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customer_Projects",
                columns: table => new
                {
                    KsCustomerId = table.Column<int>(nullable: false),
                    KsProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Projects", x => new { x.KsCustomerId, x.KsProjectId });
                    table.ForeignKey(
                        name: "FK_Customer_Projects_KsCustomers_KsCustomerId",
                        column: x => x.KsCustomerId,
                        principalTable: "KsCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customer_Projects_KsProjectViewModel_KsProjectId",
                        column: x => x.KsProjectId,
                        principalTable: "KsProjectViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KsAddressViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    IsBillingAddress = table.Column<bool>(nullable: false),
                    KsCustomerFk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KsAddressViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KsAddressViewModel_KsCustomers_KsCustomerFk",
                        column: x => x.KsCustomerFk,
                        principalTable: "KsCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_services_KsCustomerEntityId",
                table: "Employee_services",
                column: "KsCustomerEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Projects_KsProjectId",
                table: "Customer_Projects",
                column: "KsProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_KsAddressViewModel_KsCustomerFk",
                table: "KsAddressViewModel",
                column: "KsCustomerFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_services_KsCustomers_KsCustomerEntityId",
                table: "Employee_services",
                column: "KsCustomerEntityId",
                principalTable: "KsCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_services_KsCustomers_KsCustomerEntityId",
                table: "Employee_services");

            migrationBuilder.DropTable(
                name: "Customer_Projects");

            migrationBuilder.DropTable(
                name: "KsAddressViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Employee_services_KsCustomerEntityId",
                table: "Employee_services");

            migrationBuilder.DropColumn(
                name: "InvoiceType",
                table: "KsCustomers");

            migrationBuilder.DropColumn(
                name: "KsCustomerEntityId",
                table: "Employee_services");

            migrationBuilder.AddColumn<int>(
                name: "CustomerFk",
                table: "KsProjectViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "KsProjectViewModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "KsCustomers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "KsCustomers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "KsCustomers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "KsCustomers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "KsCustomers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KsProjectViewModel_CustomerId",
                table: "KsProjectViewModel",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_KsProjectViewModel_KsCustomers_CustomerId",
                table: "KsProjectViewModel",
                column: "CustomerId",
                principalTable: "KsCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
