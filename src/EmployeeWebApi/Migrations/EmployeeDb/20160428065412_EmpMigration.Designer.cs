using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using EmployeeWebApi.Models;

namespace EmployeeWebApi.Migrations.EmployeeDb
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20160428065412_EmpMigration")]
    partial class EmpMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("EmployeeWebApi.Models.EmployeeMasters", b =>
                {
                    b.Property<int>("EmpID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Designation")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("EmpName")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.HasKey("EmpID");
                });
        }
    }
}
