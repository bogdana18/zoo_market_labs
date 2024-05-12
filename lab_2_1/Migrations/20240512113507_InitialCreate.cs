using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab21.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "zoo");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:pg_catalog.adminpack", ",,");

            migrationBuilder.CreateTable(
                name: "customer",
                schema: "zoo",
                columns: table => new
                {
                    customerid = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    phone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("customer_pkey", x => x.customerid);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                schema: "zoo",
                columns: table => new
                {
                    employeeid = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    position = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    salary = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("employee_pkey", x => x.employeeid);
                });

            migrationBuilder.CreateTable(
                name: "pet",
                schema: "zoo",
                columns: table => new
                {
                    petid = table.Column<int>(type: "integer", nullable: false),
                    species = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    breed = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    birthdate = table.Column<DateOnly>(type: "date", nullable: true),
                    healthstatus = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pet_pkey", x => x.petid);
                });

            migrationBuilder.CreateTable(
                name: "product",
                schema: "zoo",
                columns: table => new
                {
                    productid = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    price = table.Column<double>(type: "double precision", nullable: true),
                    category = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    stockquantity = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("product_pkey", x => x.productid);
                });

            migrationBuilder.CreateTable(
                name: "sale",
                schema: "zoo",
                columns: table => new
                {
                    saleid = table.Column<int>(type: "integer", nullable: false),
                    customerid = table.Column<int>(type: "integer", nullable: true),
                    employeeid = table.Column<int>(type: "integer", nullable: true),
                    petid = table.Column<int>(type: "integer", nullable: true),
                    productid = table.Column<int>(type: "integer", nullable: true),
                    saledate = table.Column<DateOnly>(type: "date", nullable: true),
                    totalamount = table.Column<double>(type: "double precision", nullable: true),
                    paymentmethod = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sale_pkey", x => x.saleid);
                    table.ForeignKey(
                        name: "sale_customerid_fkey",
                        column: x => x.customerid,
                        principalSchema: "zoo",
                        principalTable: "customer",
                        principalColumn: "customerid");
                    table.ForeignKey(
                        name: "sale_employeeid_fkey",
                        column: x => x.employeeid,
                        principalSchema: "zoo",
                        principalTable: "employee",
                        principalColumn: "employeeid");
                    table.ForeignKey(
                        name: "sale_petid_fkey",
                        column: x => x.petid,
                        principalSchema: "zoo",
                        principalTable: "pet",
                        principalColumn: "petid");
                    table.ForeignKey(
                        name: "sale_productid_fkey",
                        column: x => x.productid,
                        principalSchema: "zoo",
                        principalTable: "product",
                        principalColumn: "productid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_sale_customerid",
                schema: "zoo",
                table: "sale",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_sale_employeeid",
                schema: "zoo",
                table: "sale",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "IX_sale_petid",
                schema: "zoo",
                table: "sale",
                column: "petid");

            migrationBuilder.CreateIndex(
                name: "IX_sale_productid",
                schema: "zoo",
                table: "sale",
                column: "productid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sale",
                schema: "zoo");

            migrationBuilder.DropTable(
                name: "customer",
                schema: "zoo");

            migrationBuilder.DropTable(
                name: "employee",
                schema: "zoo");

            migrationBuilder.DropTable(
                name: "pet",
                schema: "zoo");

            migrationBuilder.DropTable(
                name: "product",
                schema: "zoo");
        }
    }
}
