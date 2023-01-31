using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreApp.API.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUserandRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "40ea3c8c-f25e-4861-ae90-a1af1e8a18fa", "c015da05-7052-4f7b-9eec-d8b8eff8f6e9", "Administrator", "ADMINISTRATOR" },
                    { "692d3644-360c-45a4-9332-4a40bcb73dcc", "6558d737-6ea5-4fe7-8230-4fe8439dc047", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "45487ca1-e630-4334-8052-caa404e1ac5c", 0, "acce4915-169b-4702-9db1-aab29e7638ba", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEEV2yxfQuQuxS5UC/9izWXBPKCP4+oWpCCtLZ1hWUg+T0Tgmd0HjvU39Rf6QFYFf+Q==", null, false, "69072e82-4fcb-4422-82a4-93e11b7467c3", false, "admin@bookstore.com" },
                    { "f3b3b6ce-6d74-4dce-a2fe-d57fdba157e5", 0, "6f257ec6-1b87-4d6e-909a-be8ade6ad306", "user@bookstore.com", false, "System", "Udmin", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEHG14oZ+GmlRV5H6dTXxMN5l2GUSxk5UadMyQOj4akAKSunxj+v6WO0/rw+x7Xl5yQ==", null, false, "ff275e8d-aaef-4ba3-92d8-cdcdde56cd51", false, "user@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "40ea3c8c-f25e-4861-ae90-a1af1e8a18fa", "f3b3b6ce-6d74-4dce-a2fe-d57fdba157e5" },
                    { "692d3644-360c-45a4-9332-4a40bcb73dcc", "f3b3b6ce-6d74-4dce-a2fe-d57fdba157e5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "40ea3c8c-f25e-4861-ae90-a1af1e8a18fa", "f3b3b6ce-6d74-4dce-a2fe-d57fdba157e5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "692d3644-360c-45a4-9332-4a40bcb73dcc", "f3b3b6ce-6d74-4dce-a2fe-d57fdba157e5" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45487ca1-e630-4334-8052-caa404e1ac5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40ea3c8c-f25e-4861-ae90-a1af1e8a18fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "692d3644-360c-45a4-9332-4a40bcb73dcc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b6ce-6d74-4dce-a2fe-d57fdba157e5");
        }
    }
}
