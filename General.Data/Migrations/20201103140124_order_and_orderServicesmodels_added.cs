using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class order_and_orderServicesmodels_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerMode = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true),
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
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    OrderFK = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderServices_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderServices_OrderId",
                table: "OrderServices",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderServices");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
