using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplierManagement.Data.Migrations
{
    public partial class suppliernullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bab5ce50-84b3-456c-98f1-d7ff6d40e46e",
                column: "ConcurrencyStamp",
                value: "012b746e-14d9-45b5-a42d-fbb74b151ba7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be4a0261-3e09-46cf-896a-74275d5ef8cd",
                column: "ConcurrencyStamp",
                value: "8438ebd8-a20a-438e-b29d-05de077d81d9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1cfdbb18-b4f8-40c1-9d79-0498d2001c32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "913c9fba-de7d-45d3-8acf-cdf3bdf2b36c", "AQAAAAEAACcQAAAAED8XBMb43HYI2+gWJCdFlheyHT3JpbBAYoinj3xXH0hF85EsGe5i40w5MqyTQITfNg==", "85d5c3b2-9036-4624-a719-f660a91f783d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c1e9f47-a2b2-43a2-8a23-53a9710e3248",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea69f7a9-ae49-49a3-9e03-52817258f635", "AQAAAAEAACcQAAAAEOIQUY8DDeR/8kIlR4gQc8yqYAcr1lVyDjn6jflzoTxMdX9oYGQxbPJWPS0HLOD+Rw==", "061ff912-faea-42e1-bb9e-66f863a6d68f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
