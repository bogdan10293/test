using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class test_if_problems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerMode = table.Column<int>(nullable: false),
                    CustomerNo = table.Column<string>(nullable: true),
                    CompanyNo = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    VatNo = table.Column<string>(nullable: true),
                    GlnNo = table.Column<string>(nullable: true),
                    WebUrl = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    InvoiceEmail = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer_Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerMode = table.Column<int>(nullable: false),
                    CustomerFK = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    QuotedPrice = table.Column<decimal>(nullable: false),
                    IsIncludingVAT = table.Column<bool>(nullable: false),
                    IsPrivate = table.Column<bool>(nullable: false),
                    OrderDate = table.Column<string>(nullable: true),
                    WhenInTheDayId = table.Column<int>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    WorkAddressStreet = table.Column<string>(nullable: true),
                    WorkAddressZipCode = table.Column<string>(nullable: true),
                    WorkAddressCity = table.Column<string>(nullable: true),
                    RegNo = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    EMail = table.Column<string>(nullable: true),
                    SendConfirmationEmail = table.Column<bool>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    SendInvoiceByEmail = table.Column<bool>(nullable: false),
                    OtherInvoiceAddress = table.Column<bool>(nullable: false),
                    InvoiceAddressStreet = table.Column<string>(nullable: true),
                    InvoiceAddressZipCode = table.Column<string>(nullable: true),
                    InvoiceAddressCity = table.Column<string>(nullable: true),
                    HowDoWeGetIn = table.Column<string>(nullable: true),
                    CleaningMaterialsOnSite = table.Column<bool>(nullable: false),
                    FurAnimalsIsOnSite = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Orders_Customers_CustomerFK",
                        column: x => x.CustomerFK,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer_Order_Services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    OrderFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Order_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Order_Services_Customer_Orders_OrderFK",
                        column: x => x.OrderFK,
                        principalTable: "Customer_Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Order_Services_OrderFK",
                table: "Customer_Order_Services",
                column: "OrderFK");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Orders_CustomerFK",
                table: "Customer_Orders",
                column: "CustomerFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer_Order_Services");

            migrationBuilder.DropTable(
                name: "Customer_Orders");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
