using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace EmployeeWebApi.Migrations.EmployeeDb
{
    public partial class EmpMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeMasters",
                columns: table => new
                {
                    EmpID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(nullable: false),
                    Designation = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    EmpName = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMasters", x => x.EmpID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("EmployeeMasters");
        }
    }
}
