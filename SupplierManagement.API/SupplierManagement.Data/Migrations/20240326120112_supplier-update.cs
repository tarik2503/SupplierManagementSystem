using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplierManagement.Data.Migrations
{
    public partial class supplierupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "Suppliers");

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
        }
    }
}
