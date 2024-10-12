using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalSystem.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class department : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19c5a0c3-3552-468f-8498-3689331da259", null, "Doctor", "DOCTOR" },
                    { "33e3582a-4d10-40d9-a2fa-a3539d93f809", null, "Patient", "PATIENT" },
                    { "6c27ecca-ce21-414b-9808-b1c05fe4d37a", null, "Nurse", "NURSE" },
                    { "f94d5f17-7588-4c66-806c-b003c10fb5d0", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "Img", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "22e7cd88-254d-4d27-a2c9-29e6586c8ee0", 0, null, "4264f990-d8b7-4704-a8cd-1b6375a83225", null, new DateTime(2003, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, "Admin", 0, null, "User", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAECtXOsGhb8eH1/9laKqZSVmpMGeKhEFd6F2bmeDctZIHBuClQAZiYschDTyVO90f/A==", null, false, "4039a117-dadf-4667-9786-ee54b3e73a65", false, "admin@admin.com", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f94d5f17-7588-4c66-806c-b003c10fb5d0", "22e7cd88-254d-4d27-a2c9-29e6586c8ee0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19c5a0c3-3552-468f-8498-3689331da259");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33e3582a-4d10-40d9-a2fa-a3539d93f809");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c27ecca-ce21-414b-9808-b1c05fe4d37a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f94d5f17-7588-4c66-806c-b003c10fb5d0", "22e7cd88-254d-4d27-a2c9-29e6586c8ee0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f94d5f17-7588-4c66-806c-b003c10fb5d0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22e7cd88-254d-4d27-a2c9-29e6586c8ee0");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "Departments");

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
        }
    }
}
