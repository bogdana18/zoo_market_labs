﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using lab_2_1.Models;

#nullable disable

namespace lab21.Migrations
{
    [DbContext(typeof(ZooContext))]
    [Migration("20240512113507_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pg_catalog", "adminpack");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("lab_2_1.Models.Customer", b =>
                {
                    b.Property<int>("Customerid")
                        .HasColumnType("integer")
                        .HasColumnName("customerid");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("address");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("phone");

                    b.HasKey("Customerid")
                        .HasName("customer_pkey");

                    b.ToTable("customer", "zoo");
                });

            modelBuilder.Entity("lab_2_1.Models.Employee", b =>
                {
                    b.Property<int>("Employeeid")
                        .HasColumnType("integer")
                        .HasColumnName("employeeid");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<string>("Position")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("position");

                    b.Property<double?>("Salary")
                        .HasColumnType("double precision")
                        .HasColumnName("salary");

                    b.HasKey("Employeeid")
                        .HasName("employee_pkey");

                    b.ToTable("employee", "zoo");
                });

            modelBuilder.Entity("lab_2_1.Models.Pet", b =>
                {
                    b.Property<int>("Petid")
                        .HasColumnType("integer")
                        .HasColumnName("petid");

                    b.Property<DateOnly?>("Birthdate")
                        .HasColumnType("date")
                        .HasColumnName("birthdate");

                    b.Property<string>("Breed")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("breed");

                    b.Property<string>("Healthstatus")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("healthstatus");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<string>("Species")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("species");

                    b.HasKey("Petid")
                        .HasName("pet_pkey");

                    b.ToTable("pet", "zoo");
                });

            modelBuilder.Entity("lab_2_1.Models.Product", b =>
                {
                    b.Property<int>("Productid")
                        .HasColumnType("integer")
                        .HasColumnName("productid");

                    b.Property<string>("Category")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("category");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<double?>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<int?>("Stockquantity")
                        .HasColumnType("integer")
                        .HasColumnName("stockquantity");

                    b.HasKey("Productid")
                        .HasName("product_pkey");

                    b.ToTable("product", "zoo");
                });

            modelBuilder.Entity("lab_2_1.Models.Sale", b =>
                {
                    b.Property<int>("Saleid")
                        .HasColumnType("integer")
                        .HasColumnName("saleid");

                    b.Property<int?>("Customerid")
                        .HasColumnType("integer")
                        .HasColumnName("customerid");

                    b.Property<int?>("Employeeid")
                        .HasColumnType("integer")
                        .HasColumnName("employeeid");

                    b.Property<string>("Paymentmethod")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("paymentmethod");

                    b.Property<int?>("Petid")
                        .HasColumnType("integer")
                        .HasColumnName("petid");

                    b.Property<int?>("Productid")
                        .HasColumnType("integer")
                        .HasColumnName("productid");

                    b.Property<DateOnly?>("Saledate")
                        .HasColumnType("date")
                        .HasColumnName("saledate");

                    b.Property<double?>("Totalamount")
                        .HasColumnType("double precision")
                        .HasColumnName("totalamount");

                    b.HasKey("Saleid")
                        .HasName("sale_pkey");

                    b.HasIndex("Customerid");

                    b.HasIndex("Employeeid");

                    b.HasIndex("Petid");

                    b.HasIndex("Productid");

                    b.ToTable("sale", "zoo");
                });

            modelBuilder.Entity("lab_2_1.Models.Sale", b =>
                {
                    b.HasOne("lab_2_1.Models.Customer", "Customer")
                        .WithMany("Sales")
                        .HasForeignKey("Customerid")
                        .HasConstraintName("sale_customerid_fkey");

                    b.HasOne("lab_2_1.Models.Employee", "Employee")
                        .WithMany("Sales")
                        .HasForeignKey("Employeeid")
                        .HasConstraintName("sale_employeeid_fkey");

                    b.HasOne("lab_2_1.Models.Pet", "Pet")
                        .WithMany("Sales")
                        .HasForeignKey("Petid")
                        .HasConstraintName("sale_petid_fkey");

                    b.HasOne("lab_2_1.Models.Product", "Product")
                        .WithMany("Sales")
                        .HasForeignKey("Productid")
                        .HasConstraintName("sale_productid_fkey");

                    b.Navigation("Customer");

                    b.Navigation("Employee");

                    b.Navigation("Pet");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("lab_2_1.Models.Customer", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("lab_2_1.Models.Employee", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("lab_2_1.Models.Pet", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("lab_2_1.Models.Product", b =>
                {
                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
