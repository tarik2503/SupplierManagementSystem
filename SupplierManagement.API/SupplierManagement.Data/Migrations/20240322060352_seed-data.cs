using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplierManagement.Data.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bab5ce50-84b3-456c-98f1-d7ff6d40e46e", "9586d1a8-6722-4f04-86e0-dd527802bcd7", "User", "USER" },
                    { "be4a0261-3e09-46cf-896a-74275d5ef8cd", "85b9f3d8-2820-47b9-a59e-9dc8ced2e1ff", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1cfdbb18-b4f8-40c1-9d79-0498d2001c32", 0, "887a7042-3a57-42ad-986e-6df8fff71cbb", "user@gmail.com", true, "User", "User", false, null, "user@gmail.com", null, "AQAAAAEAACcQAAAAEAiPETLB1QdTZjNsN9SNNm5RalxjIiucnFZxANl8PVLkl3FyQ1BIKFbd5difKnJLnw==", null, false, "7d64597d-7317-4395-9578-3aeae8964a64", false, "user@gmail.com" },
                    { "8c1e9f47-a2b2-43a2-8a23-53a9710e3248", 0, "ec464a01-4470-4ec8-9c24-091edf4b249b", "admin@gmail.com", true, "Admin", "Admin", false, null, "admin@gmail.com", null, "AQAAAAEAACcQAAAAEDwL/PeN3GsS7mxhhi4XmWmR97sKvcvSHOXD+QbnY0RGSP0M8NGWrQ4xJvQ7xphOww==", null, false, "e55a5f8f-550f-4e2c-b4f1-40390ea15dba", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bab5ce50-84b3-456c-98f1-d7ff6d40e46e", "1cfdbb18-b4f8-40c1-9d79-0498d2001c32" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "be4a0261-3e09-46cf-896a-74275d5ef8cd", "8c1e9f47-a2b2-43a2-8a23-53a9710e3248" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bab5ce50-84b3-456c-98f1-d7ff6d40e46e", "1cfdbb18-b4f8-40c1-9d79-0498d2001c32" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "be4a0261-3e09-46cf-896a-74275d5ef8cd", "8c1e9f47-a2b2-43a2-8a23-53a9710e3248" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bab5ce50-84b3-456c-98f1-d7ff6d40e46e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be4a0261-3e09-46cf-896a-74275d5ef8cd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1cfdbb18-b4f8-40c1-9d79-0498d2001c32");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c1e9f47-a2b2-43a2-8a23-53a9710e3248");
        }
    }
}
