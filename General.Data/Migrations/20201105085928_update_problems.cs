using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class update_problems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderServices");

            migrationBuilder.DropTable(
                name: "Order_services");

            migrationBuilder.DropTable(
                name: "Customer_orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer_orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerMode = table.Column<int>(type: "int", nullable: false),
                    CustomerNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlnNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VatNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order_services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CleaningMaterialsOnSite = table.Column<bool>(type: "bit", nullable: false),
                    CustomerFK = table.Column<int>(type: "int", nullable: false),
                    CustomerMode = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FurAnimalsIsOnSite = table.Column<bool>(type: "bit", nullable: false),
                    HowDoWeGetIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAddressCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceAddressZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsIncludingVAT = table.Column<bool>(type: "bit", nullable: false),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherInvoiceAddress = table.Column<bool>(type: "bit", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuotedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RegNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendConfirmationEmail = table.Column<bool>(type: "bit", nullable: false),
                    SendInvoiceByEmail = table.Column<bool>(type: "bit", nullable: false),
                    WhenInTheDayId = table.Column<int>(type: "int", nullable: false),
                    WorkAddressCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkAddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkAddressZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_services_Customer_orders_CustomerFK",
                        column: x => x.CustomerFK,
                        principalTable: "Customer_orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderServices_Order_services_OrderFK",
                        column: x => x.OrderFK,
                        principalTable: "Order_services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_services_CustomerFK",
                table: "Order_services",
                column: "CustomerFK");

            migrationBuilder.CreateIndex(
                name: "IX_OrderServices_OrderFK",
                table: "OrderServices",
                column: "OrderFK");
        }
    }
}
