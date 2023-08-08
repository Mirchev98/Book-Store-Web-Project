using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    public partial class CartAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f0fcc62b-6cfc-4615-8873-1b7c5be5187b"));

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CartId", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("48757c4e-aca3-41dd-b3a6-792855ec770a"), 0, 0, "4cd916bc-a8e2-4efe-b454-ea6c26ac6cfa", "admin@admin.com", false, false, false, null, "admin@admin.com", "admin@admin.com", "AJeYOH+nWIiy5oxkqkmnS3rrC4EWltJshmBP52oGJbbZz4V7R43VpO7OfOS359v8xw==", null, false, null, false, "admin@admin.com" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CartId",
                table: "Books",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Carts_CartId",
                table: "Books",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Carts_CartId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Books_CartId",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("48757c4e-aca3-41dd-b3a6-792855ec770a"));

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("f0fcc62b-6cfc-4615-8873-1b7c5be5187b"), 0, "f48ca980-f7e5-42c0-945d-42d83388364c", "admin@admin.com", false, false, false, null, "admin@admin.com", "admin@admin.com", "AOdNNxn8wUzTM5rSk0yMCtbvRxAmqvEf04VZp53SxJYShX6bga1Sg98lAYC5kfi4/A==", null, false, null, false, "admin@admin.com" });
        }
    }
}
