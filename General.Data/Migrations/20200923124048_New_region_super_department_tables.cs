using Microsoft.EntityFrameworkCore.Migrations;

namespace General.Data.Migrations
{
    public partial class New_region_super_department_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDepartmentJoins_Departments_DepartmentId",
                table: "EmployeeDepartmentJoins");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDepartmentJoins_KsEmployees_EmployeeId",
                table: "EmployeeDepartmentJoins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDepartmentJoins",
                table: "EmployeeDepartmentJoins");

            migrationBuilder.RenameTable(
                name: "EmployeeDepartmentJoins",
                newName: "Employee_departments");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDepartmentJoins_DepartmentId",
                table: "Employee_departments",
                newName: "IX_Employee_departments_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee_departments",
                table: "Employee_departments",
                columns: new[] { "EmployeeId", "DepartmentId" });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CostCarrierNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supervisors",
                columns: table => new
                {
                    SupervisorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostCarrierNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Mobile = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisors", x => x.SupervisorId);
                });

            migrationBuilder.CreateTable(
                name: "Employee_regions",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    RegionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_regions", x => new { x.EmployeeId, x.RegionId });
                    table.ForeignKey(
                        name: "FK_Employee_regions_KsEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "KsEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_regions_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee_supervisors",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    SupervisorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_supervisors", x => new { x.EmployeeId, x.SupervisorId });
                    table.ForeignKey(
                        name: "FK_Employee_supervisors_KsEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "KsEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_supervisors_Supervisors_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Supervisors",
                        principalColumn: "SupervisorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_regions_RegionId",
                table: "Employee_regions",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_supervisors_SupervisorId",
                table: "Employee_supervisors",
                column: "SupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_departments_Departments_DepartmentId",
                table: "Employee_departments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_departments_KsEmployees_EmployeeId",
                table: "Employee_departments",
                column: "EmployeeId",
                principalTable: "KsEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_departments_Departments_DepartmentId",
                table: "Employee_departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_departments_KsEmployees_EmployeeId",
                table: "Employee_departments");

            migrationBuilder.DropTable(
                name: "Employee_regions");

            migrationBuilder.DropTable(
                name: "Employee_supervisors");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Supervisors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee_departments",
                table: "Employee_departments");

            migrationBuilder.RenameTable(
                name: "Employee_departments",
                newName: "EmployeeDepartmentJoins");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_departments_DepartmentId",
                table: "EmployeeDepartmentJoins",
                newName: "IX_EmployeeDepartmentJoins_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDepartmentJoins",
                table: "EmployeeDepartmentJoins",
                columns: new[] { "EmployeeId", "DepartmentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDepartmentJoins_Departments_DepartmentId",
                table: "EmployeeDepartmentJoins",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDepartmentJoins_KsEmployees_EmployeeId",
                table: "EmployeeDepartmentJoins",
                column: "EmployeeId",
                principalTable: "KsEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
