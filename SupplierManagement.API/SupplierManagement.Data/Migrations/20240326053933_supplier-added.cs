using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplierManagement.Data.Migrations
{
    public partial class supplieradded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bab5ce50-84b3-456c-98f1-d7ff6d40e46e",
                column: "ConcurrencyStamp",
                value: "591f10ff-8f14-4e3d-a12f-c7d467ed50da");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be4a0261-3e09-46cf-896a-74275d5ef8cd",
                column: "ConcurrencyStamp",
                value: "8b300144-3669-41ad-a95c-e3410d460243");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1cfdbb18-b4f8-40c1-9d79-0498d2001c32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7f94e48-7dc4-4d04-90a1-a3981e31fc5c", "AQAAAAEAACcQAAAAEMXm7J6r+vv39G4WM6hlXNhf3odwwe9FrzJf/11BK3iEIY/eG9fvqxlyMVg/qpdVqQ==", "3931b423-1f2c-47e7-a321-4dc5227974c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c1e9f47-a2b2-43a2-8a23-53a9710e3248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9df6f0f5-52bb-4899-a6da-5e0a9934439e", "AQAAAAEAACcQAAAAEGXCdAfrv/Nl4tlHBhePxvfvw8H2fD+P0EKl+YY9I24z+BgEARe24UXaAmumpCWwNQ==", "22dd2721-5a2f-414d-b471-191629eeeda6" });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_UserId",
                table: "Suppliers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bab5ce50-84b3-456c-98f1-d7ff6d40e46e",
                column: "ConcurrencyStamp",
                value: "9586d1a8-6722-4f04-86e0-dd527802bcd7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be4a0261-3e09-46cf-896a-74275d5ef8cd",
                column: "ConcurrencyStamp",
                value: "85b9f3d8-2820-47b9-a59e-9dc8ced2e1ff");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1cfdbb18-b4f8-40c1-9d79-0498d2001c32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "887a7042-3a57-42ad-986e-6df8fff71cbb", "AQAAAAEAACcQAAAAEAiPETLB1QdTZjNsN9SNNm5RalxjIiucnFZxANl8PVLkl3FyQ1BIKFbd5difKnJLnw==", "7d64597d-7317-4395-9578-3aeae8964a64" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c1e9f47-a2b2-43a2-8a23-53a9710e3248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec464a01-4470-4ec8-9c24-091edf4b249b", "AQAAAAEAACcQAAAAEDwL/PeN3GsS7mxhhi4XmWmR97sKvcvSHOXD+QbnY0RGSP0M8NGWrQ4xJvQ7xphOww==", "e55a5f8f-550f-4e2c-b4f1-40390ea15dba" });
        }
    }
}
