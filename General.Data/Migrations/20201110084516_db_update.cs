using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class db_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KsCustomer");

            migrationBuilder.DropColumn(
                name: "CleaningMaterialsOnSite",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "EMail",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "FurAnimalsIsOnSite",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "HowDoWeGetIn",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "InvoiceAddressCity",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "InvoiceAddressStreet",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "InvoiceAddressZipCode",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "IsIncludingVAT",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "OtherInvoiceAddress",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "QuotedPrice",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "RegNo",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "SendConfirmationEmail",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "SendInvoiceByEmail",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "WhenInTheDayId",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "WorkAddressCity",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "WorkAddressStreet",
                table: "Customer_Orders");

            migrationBuilder.DropColumn(
                name: "WorkAddressZipCode",
                table: "Customer_Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CleaningMaterialsOnSite",
                table: "Customer_Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Customer_Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EMail",
                table: "Customer_Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FurAnimalsIsOnSite",
                table: "Customer_Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "HowDoWeGetIn",
                table: "Customer_Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceAddressCity",
                table: "Customer_Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceAddressStreet",
                table: "Customer_Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceAddressZipCode",
                table: "Customer_Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsIncludingVAT",
                table: "Customer_Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Customer_Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Customer_Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Customer_Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OtherInvoiceAddress",
                table: "Customer_Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Customer_Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "QuotedPrice",
                table: "Customer_Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "RegNo",
                table: "Customer_Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SendConfirmationEmail",
                table: "Customer_Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SendInvoiceByEmail",
                table: "Customer_Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "WhenInTheDayId",
                table: "Customer_Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WorkAddressCity",
                table: "Customer_Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkAddressStreet",
                table: "Customer_Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkAddressZipCode",
                table: "Customer_Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KsCustomer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerType = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notification = table.Column<bool>(type: "bit", nullable: false),
                    OrganisationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalIdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TangellaCustomerId = table.Column<int>(type: "int", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KsCustomer", x => x.Id);
                });
        }
    }
}
