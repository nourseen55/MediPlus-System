using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalSystem.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class newDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ad44c81-44b1-44c4-811d-4be3a26b544b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3547810f-37a2-43a5-a172-6f7442caa3a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a510e06-ba53-44ae-a4b5-079fb4cd0652");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5e40a3d6-1ce7-4b51-b575-874b377a07fe", "a8a4bb71-359d-4ee4-aef9-87f7d8405f53" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e40a3d6-1ce7-4b51-b575-874b377a07fe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8a4bb71-359d-4ee4-aef9-87f7d8405f53");

            migrationBuilder.AlterColumn<string>(
                name: "FieldOfStudy",
                table: "Educations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "620e1ef2-f635-47b8-bf60-d7fe7b7fa72e", null, "Patient", "PATIENT" },
                    { "7c15fa01-92a1-4931-ac2f-954220ef0cce", null, "Doctor", "DOCTOR" },
                    { "d7e0a967-3064-4459-8489-1e3e1a86a7d9", null, "Admin", "ADMIN" },
                    { "ee35d020-d0a8-4cd7-82f4-7fbce01e42a1", null, "Nurse", "NURSE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "Img", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "3b4890c1-cb1b-490f-99f1-4b2e86b45f35", 0, null, "bad17dbb-19a5-41cf-93f2-d3b53dd38135", null, new DateTime(2003, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, "Admin", 0, null, "User", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEFekZe1kug+BKFDPBl8d0HFRoHzxJ6KLfKEcZ1vrW4q6mrNZ9gUWo+MExYerXxouAA==", null, false, "41b36cfe-9c1f-4db0-b3e8-5f3ee5816c29", false, "admin@admin.com", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d7e0a967-3064-4459-8489-1e3e1a86a7d9", "3b4890c1-cb1b-490f-99f1-4b2e86b45f35" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "620e1ef2-f635-47b8-bf60-d7fe7b7fa72e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c15fa01-92a1-4931-ac2f-954220ef0cce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee35d020-d0a8-4cd7-82f4-7fbce01e42a1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d7e0a967-3064-4459-8489-1e3e1a86a7d9", "3b4890c1-cb1b-490f-99f1-4b2e86b45f35" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7e0a967-3064-4459-8489-1e3e1a86a7d9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b4890c1-cb1b-490f-99f1-4b2e86b45f35");

            migrationBuilder.AlterColumn<string>(
                name: "FieldOfStudy",
                table: "Educations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ad44c81-44b1-44c4-811d-4be3a26b544b", null, "Patient", "PATIENT" },
                    { "3547810f-37a2-43a5-a172-6f7442caa3a6", null, "Doctor", "DOCTOR" },
                    { "5e40a3d6-1ce7-4b51-b575-874b377a07fe", null, "Admin", "ADMIN" },
                    { "8a510e06-ba53-44ae-a4b5-079fb4cd0652", null, "Nurse", "NURSE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "Img", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "a8a4bb71-359d-4ee4-aef9-87f7d8405f53", 0, null, "e7108f27-6994-49c3-8713-7d23a2b39d42", null, new DateTime(2003, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, "Admin", 0, null, "User", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEHVpT7EM2mW6f8xaPY+ngxvRYAAwHeoLEXsDdQo9/4hNUjlpioMfnAhVKe7DcYkFmQ==", null, false, "58aaa532-58e7-4f82-bf1d-a1e253e31b21", false, "admin@admin.com", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5e40a3d6-1ce7-4b51-b575-874b377a07fe", "a8a4bb71-359d-4ee4-aef9-87f7d8405f53" });
        }
    }
}
