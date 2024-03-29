using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplierManagement.Data.Migrations
{
    public partial class productupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bab5ce50-84b3-456c-98f1-d7ff6d40e46e",
                column: "ConcurrencyStamp",
                value: "23c33067-6890-4641-81a7-2c1dee713dfa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be4a0261-3e09-46cf-896a-74275d5ef8cd",
                column: "ConcurrencyStamp",
                value: "b30eba17-d39e-4ff2-9fec-68c0145a3a14");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1cfdbb18-b4f8-40c1-9d79-0498d2001c32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c961d28-00f3-4d36-b892-81d2c22fe8e1", "AQAAAAEAACcQAAAAECv2zhS6xjx3fl1r1dhZbAUPkTeAW9OuzNYEmVHB/rsODrFKHceJnXL5eB8cJizmhA==", "9658dcbf-a3f2-44f7-88bc-e9164f2583c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c1e9f47-a2b2-43a2-8a23-53a9710e3248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8318bcd4-e8c0-4979-9222-46d522b681b8", "AQAAAAEAACcQAAAAEEGfMxUVDZvwny6mUIZg2iw7oPi9VUgwFVmiRYXL8kar7YhOIw3FjcxmVZRQBTjB6A==", "50556a7e-a905-4566-982a-781dc34deffe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
