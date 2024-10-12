using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalSystem.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class @as : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_feedbacks_AspNetUsers_ApplicationUserId",
                table: "feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_feedbacks_ApplicationUserId",
                table: "feedbacks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b97bd3a-e89e-451c-804a-592eae5746a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adfced05-7d0c-4243-a0d9-0d39e987cf17");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc88576c-1a1f-4886-8c22-123ecec98b8d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bfecdab5-ff93-4129-bf73-457932eb6b6d", "ac53451b-3abe-417b-ba33-cf3360253d89" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfecdab5-ff93-4129-bf73-457932eb6b6d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac53451b-3abe-417b-ba33-cf3360253d89");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "feedbacks");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "feedbacks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "452c6910-1a20-46a2-bfc9-33b898399f1f", null, "Admin", "ADMIN" },
                    { "87502ae8-3c94-4f21-b31c-a83ccbc392e3", null, "Patient", "PATIENT" },
                    { "90aa44ff-7b50-4a8e-8cac-7304ea1155f2", null, "Doctor", "DOCTOR" },
                    { "d8ebd5d2-4b89-48dd-9c68-282f9b40ffbf", null, "Nurse", "NURSE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "Img", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "3d62137e-f8b6-4a31-ad9c-79dea4ad1372", 0, null, "3a200313-489a-4904-a8e4-3a58fd495c63", null, new DateTime(2003, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, "Admin", 0, null, "User", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEIEaU0VHnsuG1wYkht5nzGHsGhsc+aYlySWG5aS+VqlpMfeqKf42XFs78Pp2aw1qAA==", null, false, "1eea1e65-9e39-44a8-952c-5f81d2e701d2", false, "admin@admin.com", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "452c6910-1a20-46a2-bfc9-33b898399f1f", "3d62137e-f8b6-4a31-ad9c-79dea4ad1372" });

            migrationBuilder.CreateIndex(
                name: "IX_feedbacks_UserId",
                table: "feedbacks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_feedbacks_AspNetUsers_UserId",
                table: "feedbacks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_feedbacks_AspNetUsers_UserId",
                table: "feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_feedbacks_UserId",
                table: "feedbacks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87502ae8-3c94-4f21-b31c-a83ccbc392e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90aa44ff-7b50-4a8e-8cac-7304ea1155f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8ebd5d2-4b89-48dd-9c68-282f9b40ffbf");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "452c6910-1a20-46a2-bfc9-33b898399f1f", "3d62137e-f8b6-4a31-ad9c-79dea4ad1372" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "452c6910-1a20-46a2-bfc9-33b898399f1f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d62137e-f8b6-4a31-ad9c-79dea4ad1372");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "feedbacks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "feedbacks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b97bd3a-e89e-451c-804a-592eae5746a6", null, "Patient", "PATIENT" },
                    { "adfced05-7d0c-4243-a0d9-0d39e987cf17", null, "Doctor", "DOCTOR" },
                    { "bfecdab5-ff93-4129-bf73-457932eb6b6d", null, "Admin", "ADMIN" },
                    { "fc88576c-1a1f-4886-8c22-123ecec98b8d", null, "Nurse", "NURSE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "Img", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "ac53451b-3abe-417b-ba33-cf3360253d89", 0, null, "dec0b1eb-13e4-4900-bbb4-758229309d83", null, new DateTime(2003, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, "Admin", 0, null, "User", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEHc65RXZIQKt8d42iLTYk07jC16R0khPli2F6nmBj4rsuXm0/TlGGtjMCFUjaEQhIA==", null, false, "e361752c-a819-4427-b878-0bfd65221d0a", false, "admin@admin.com", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bfecdab5-ff93-4129-bf73-457932eb6b6d", "ac53451b-3abe-417b-ba33-cf3360253d89" });

            migrationBuilder.CreateIndex(
                name: "IX_feedbacks_ApplicationUserId",
                table: "feedbacks",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_feedbacks_AspNetUsers_ApplicationUserId",
                table: "feedbacks",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
