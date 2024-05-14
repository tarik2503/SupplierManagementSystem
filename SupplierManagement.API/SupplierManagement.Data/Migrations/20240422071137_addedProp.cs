using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplierManagement.Data.Migrations
{
    public partial class addedProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PurchaseOrders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductLists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bab5ce50-84b3-456c-98f1-d7ff6d40e46e",
                column: "ConcurrencyStamp",
                value: "a833f118-46e5-40a1-806d-3dd898166ef8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be4a0261-3e09-46cf-896a-74275d5ef8cd",
                column: "ConcurrencyStamp",
                value: "49b9c01e-1396-4e97-9a78-89e9214b7b69");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1cfdbb18-b4f8-40c1-9d79-0498d2001c32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d115011c-504c-4af3-b372-67e1b08b7ff1", "AQAAAAEAACcQAAAAED/L10VyTSMH5Bl0Lmgw/U1yUpV4C3CU1NxVVz3faf67yoqTcV2jix65KcytRH8qdA==", "f41baef6-cdd5-4206-a8ff-9708ff5b0a00" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c1e9f47-a2b2-43a2-8a23-53a9710e3248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6e4bbd0-b2f4-403c-9e82-138cc2094736", "AQAAAAEAACcQAAAAEHor2h+JfqY8KteLAq3pUfA4pslyg2O0EVxQsqVjEs/02yEA4vIxfaFz/hilq5vF9Q==", "3e3f586d-b8cd-45e6-ace5-38fe0747e90e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
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
        }
    }
}
