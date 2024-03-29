using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplierManagement.Data.Migrations
{
    public partial class productmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductSKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bab5ce50-84b3-456c-98f1-d7ff6d40e46e",
                column: "ConcurrencyStamp",
                value: "077a3c92-69f5-4359-91c7-5034c41c15bd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be4a0261-3e09-46cf-896a-74275d5ef8cd",
                column: "ConcurrencyStamp",
                value: "53d427a5-430f-446e-9ca9-f7c1ab70c4b2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1cfdbb18-b4f8-40c1-9d79-0498d2001c32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25ae3bf1-7a6e-45bf-a069-4ab95befeff5", "AQAAAAEAACcQAAAAENzyVeAxDPupm5H+YIj4lC9J1DdPUQmwAQLhvW463Zpp3vlKs4GCy6ei0NlijIhvkw==", "e1d1a011-339a-4f5b-b2be-9aeffdbc4fcf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c1e9f47-a2b2-43a2-8a23-53a9710e3248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f600d361-f18c-41a6-ab89-a66bcc31179e", "AQAAAAEAACcQAAAAEAQ4gQYQ2ALhGwsDtNZlL6D/qefyc4LptWO999EbZ8kr9Zi1QQ7G6r6LVPVnNyTS5Q==", "3773dbf7-6459-48f1-896e-43e4f5e5da76" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bab5ce50-84b3-456c-98f1-d7ff6d40e46e",
                column: "ConcurrencyStamp",
                value: "29f57a5d-4103-4e9e-8818-703c3e6ce695");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be4a0261-3e09-46cf-896a-74275d5ef8cd",
                column: "ConcurrencyStamp",
                value: "0190fcc3-dab7-4ddc-9d09-5cc6826ec30e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1cfdbb18-b4f8-40c1-9d79-0498d2001c32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bca7122-47e5-403c-8eca-1fd344883443", "AQAAAAEAACcQAAAAEMHirCcS9d3jtmNidBGsGdDPBCLIdDJNq1eRid5/HIo2pglQCEd6TlsG7uHzpJq0ZQ==", "7c0b19d1-b542-4bb9-82bd-cc3e697a9f80" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c1e9f47-a2b2-43a2-8a23-53a9710e3248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6e76caf-2521-4c76-a2f3-55b264880ca7", "AQAAAAEAACcQAAAAEK5IyrS7egOLnhS+sJ9Pq8L8K5nmcndqOwpHa27vK6Ir3yK7U0AXGSeecbvv03MZow==", "279f7702-3741-43e1-bdb3-e53669c34c65" });
        }
    }
}
