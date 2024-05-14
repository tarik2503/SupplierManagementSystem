using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplierManagement.Data.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductLists_PurchaseOrders_PurchaseOrderId",
                table: "ProductLists");

            migrationBuilder.AlterColumn<Guid>(
                name: "PurchaseOrderId",
                table: "ProductLists",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bab5ce50-84b3-456c-98f1-d7ff6d40e46e",
                column: "ConcurrencyStamp",
                value: "99fdbee6-de01-4e1d-8929-e80e9a853430");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be4a0261-3e09-46cf-896a-74275d5ef8cd",
                column: "ConcurrencyStamp",
                value: "28ae58f8-9cf2-40ca-921c-7d9bc3692a61");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1cfdbb18-b4f8-40c1-9d79-0498d2001c32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "183b05aa-a9cc-490a-87ed-25035276af96", "AQAAAAEAACcQAAAAENdrNi6+FGYp5sfACw8htzYRp6HwLaKmmgXjHIg0RZwCkc+Cr6X5U+Dg9vV8NeIejQ==", "7b1998f9-07e7-4bc3-91cb-019479ad4894" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c1e9f47-a2b2-43a2-8a23-53a9710e3248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2312e81e-e87f-442c-b315-472d94e436b7", "AQAAAAEAACcQAAAAEBQnnuML175yxZtH2xiEcw0IqaHef3VsADYXDYQHcuF/gHK/qPOIJ5lLOHxlTn8JxQ==", "b1a9f23e-d540-4761-92e3-a8e7b2134444" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLists_PurchaseOrders_PurchaseOrderId",
                table: "ProductLists",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductLists_PurchaseOrders_PurchaseOrderId",
                table: "ProductLists");

            migrationBuilder.AlterColumn<Guid>(
                name: "PurchaseOrderId",
                table: "ProductLists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bab5ce50-84b3-456c-98f1-d7ff6d40e46e",
                column: "ConcurrencyStamp",
                value: "0f78ddba-6bfc-4fec-9e53-4c879708f6b3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be4a0261-3e09-46cf-896a-74275d5ef8cd",
                column: "ConcurrencyStamp",
                value: "09f3778f-7647-49b0-af74-8cfde1c525e2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1cfdbb18-b4f8-40c1-9d79-0498d2001c32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4548a7c2-1ccd-4e8c-9890-56b7a2757a95", "AQAAAAEAACcQAAAAEJU0NL2dQVyt+4g3AveIjJTIGPmsELM8UZEwhRNH19mcK4IAY5x41H3YzqqDQjwu+Q==", "cec728a9-c4e9-4f2e-ba20-cd5a53267ff8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c1e9f47-a2b2-43a2-8a23-53a9710e3248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48cac126-7b16-4795-b81e-a8df705e54ce", "AQAAAAEAACcQAAAAECBhjlYGzz+9RMGnhty2nLuu3SXFaHShBxUB0BhHinLnNq+Xp58Q50kuwCSLQKFmXg==", "84b6dd8f-b972-4cea-bf8e-e832711d7d46" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLists_PurchaseOrders_PurchaseOrderId",
                table: "ProductLists",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
