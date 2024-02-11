using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class added_ksCustomerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_services_KsCustomers_KsCustomerEntityId",
                table: "Employee_services");

            migrationBuilder.DropIndex(
                name: "IX_Employee_services_KsCustomerEntityId",
                table: "Employee_services");

            migrationBuilder.DropColumn(
                name: "KsCustomerEntityId",
                table: "Employee_services");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KsCustomerEntityId",
                table: "Employee_services",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_services_KsCustomerEntityId",
                table: "Employee_services",
                column: "KsCustomerEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_services_KsCustomers_KsCustomerEntityId",
                table: "Employee_services",
                column: "KsCustomerEntityId",
                principalTable: "KsCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
