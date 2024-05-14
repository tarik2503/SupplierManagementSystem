using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplierManagement.Data.Migrations
{
    public partial class purchaseorderIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductLists_PurchaseOrders_PurchaseOrderId",
                table: "ProductLists");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bab5ce50-84b3-456c-98f1-d7ff6d40e46e",
                column: "ConcurrencyStamp",
                value: "35d2552c-a9f3-4877-bbb1-a62d07e383b0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be4a0261-3e09-46cf-896a-74275d5ef8cd",
                column: "ConcurrencyStamp",
                value: "4e6b8e78-95fe-41b0-817f-e574e50b2bbf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1cfdbb18-b4f8-40c1-9d79-0498d2001c32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bbdb2ed-f28e-4372-9d05-5a629421ee6e", "AQAAAAEAACcQAAAAEJfpXjvSJN3/I9J1himhwDIVfcAb78EJVMrzwTNyFd0RYc+2gQ00n/rStAB9HMgjJA==", "f26f248f-ce82-4436-97db-cda41718c78d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c1e9f47-a2b2-43a2-8a23-53a9710e3248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "539b5a87-beb3-4a69-b7bd-f543600263c9", "AQAAAAEAACcQAAAAEGSKWs1Y8F4rLsJk2Q0f+9d4y2Q6+WP1FflusE1PpcNeBDzo1ERoHpCnz+4NVNGDuQ==", "3327cc53-42af-4d38-9a1a-de794ad69802" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLists_PurchaseOrders_PurchaseOrderId",
                table: "ProductLists",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductLists_PurchaseOrders_PurchaseOrderId",
                table: "ProductLists");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bab5ce50-84b3-456c-98f1-d7ff6d40e46e",
                column: "ConcurrencyStamp",
                value: "8f957ec8-e1cf-4f3a-8bf8-94e61d97e588");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be4a0261-3e09-46cf-896a-74275d5ef8cd",
                column: "ConcurrencyStamp",
                value: "07a914c7-11de-495b-8aab-af191a936bd3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1cfdbb18-b4f8-40c1-9d79-0498d2001c32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9bc20324-2e79-486d-8669-76c302b437d9", "AQAAAAEAACcQAAAAELErMg0ilKuaaIWb0EDQl78GplWiswzjaxfM1syx5Ah9dkuH3XuB4Ixv53jqIPYjRQ==", "b6548c47-783e-4ccd-ae70-d675e36335ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c1e9f47-a2b2-43a2-8a23-53a9710e3248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec097dea-6559-4078-a1fc-16a5333d4d1f", "AQAAAAEAACcQAAAAED20M1xIKYSXkIkYxcX9U1SZbY4nCBtD9VSdz/a8cimg0veeW57gxyUHfpVO80n3hw==", "52fb0739-f729-4121-8f92-d588c2114e03" });

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
