using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNet.EFCore.CodeFirstFluentApi.MvcApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<long>(type: "bigint", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments",
                        column: x => x.DepartmentId,
                        principalSchema: "dbo",
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkills",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueIdentifer", nullable: false, defaultValueSql: "(newid())"),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Employees",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Skills",
                        column: x => x.SkillId,
                        principalSchema: "dbo",
                        principalTable: "Skills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                schema: "dbo",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_EmployeeId",
                schema: "dbo",
                table: "EmployeeSkills",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_SkillId",
                schema: "dbo",
                table: "EmployeeSkills",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSkills",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Skills",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "dbo");
        }
    }
}
