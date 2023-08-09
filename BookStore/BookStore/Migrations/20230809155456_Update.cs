using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("48757c4e-aca3-41dd-b3a6-792855ec770a"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CartId", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("9b0c1a73-265d-4a10-b3e8-45e385796a47"), 0, 0, "6074a303-7ce2-4c63-9f78-465b430e3d70", "admin@admin.com", false, false, false, null, "admin@admin.com", "admin@admin.com", "ALzfytQBytl1WoYjZpX48ZeVn3ryI4tnS81EVa10wqTUxrPjKPIN7EYM+A56LYAgnA==", null, false, null, false, "admin@admin.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9b0c1a73-265d-4a10-b3e8-45e385796a47"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CartId", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("48757c4e-aca3-41dd-b3a6-792855ec770a"), 0, 0, "4cd916bc-a8e2-4efe-b454-ea6c26ac6cfa", "admin@admin.com", false, false, false, null, "admin@admin.com", "admin@admin.com", "AJeYOH+nWIiy5oxkqkmnS3rrC4EWltJshmBP52oGJbbZz4V7R43VpO7OfOS359v8xw==", null, false, null, false, "admin@admin.com" });
        }
    }
}
