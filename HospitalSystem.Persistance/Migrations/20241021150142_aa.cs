using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalSystem.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class aa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02134d04-2c44-4d35-92a3-43d696738e37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b43e5d0-ef69-4d4a-9028-6f39e5009c96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ba38770-33ea-4c9a-82b9-343cb1c9cd8e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1407ca95-b1aa-4b4a-814d-af614e09f1cb", "e634a498-b6ad-44da-9ac6-496ebb0e4370" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1407ca95-b1aa-4b4a-814d-af614e09f1cb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e634a498-b6ad-44da-9ac6-496ebb0e4370");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "029f431b-a0b1-4fb2-897a-636d6645f4d7", null, "Doctor", "DOCTOR" },
                    { "7e01c26d-c5da-4278-ba38-893d983502cb", null, "Nurse", "NURSE" },
                    { "8c35bec5-a5cf-4495-ae58-c3af12b827ab", null, "Admin", "ADMIN" },
                    { "c2d9451b-8fd7-484b-8f91-8cf3076103c9", null, "Patient", "PATIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "Img", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "1f744c23-acf3-4179-a98a-7c78e544ea8d", 0, null, "3f3f4e30-f3a2-4097-bc39-88e5040b56a4", null, new DateTime(2003, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, "Admin", 0, null, "User", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEDpHo7+2eZSuSMBp7R0svB528uamGh8kMxF4RguawwCBLw3+xlM6Gf3/DE0Zv+E2Fw==", null, false, "911955ce-0e36-4bde-bdfd-a7b18e703c19", false, "admin@admin.com", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8c35bec5-a5cf-4495-ae58-c3af12b827ab", "1f744c23-acf3-4179-a98a-7c78e544ea8d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "029f431b-a0b1-4fb2-897a-636d6645f4d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e01c26d-c5da-4278-ba38-893d983502cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2d9451b-8fd7-484b-8f91-8cf3076103c9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8c35bec5-a5cf-4495-ae58-c3af12b827ab", "1f744c23-acf3-4179-a98a-7c78e544ea8d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c35bec5-a5cf-4495-ae58-c3af12b827ab");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f744c23-acf3-4179-a98a-7c78e544ea8d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02134d04-2c44-4d35-92a3-43d696738e37", null, "Patient", "PATIENT" },
                    { "1407ca95-b1aa-4b4a-814d-af614e09f1cb", null, "Admin", "ADMIN" },
                    { "4b43e5d0-ef69-4d4a-9028-6f39e5009c96", null, "Doctor", "DOCTOR" },
                    { "6ba38770-33ea-4c9a-82b9-343cb1c9cd8e", null, "Nurse", "NURSE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "Img", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "e634a498-b6ad-44da-9ac6-496ebb0e4370", 0, null, "0b4331c7-f938-44f7-b1fc-6c0cf747ab9d", null, new DateTime(2003, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, "Admin", 0, null, "User", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEKn/ActOzbHmuX6COVX5d/49Xw9K5Yn4/AnhbbycdTzuSuADtT3nqkg4lmVGRteb5g==", null, false, "1019f22f-be87-423b-a1b4-779cdd4831f8", false, "admin@admin.com", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1407ca95-b1aa-4b4a-814d-af614e09f1cb", "e634a498-b6ad-44da-9ac6-496ebb0e4370" });
        }
    }
}
