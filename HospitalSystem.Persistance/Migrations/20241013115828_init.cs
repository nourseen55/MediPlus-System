using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalSystem.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "188c2140-dfb7-4802-97ea-f13d49201bb8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ad342de-f79b-454c-ab2d-4c340250a560");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c41d5cc4-6b53-4d58-86c7-13dfce079b2a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5b0ccf3d-1ca0-4d3c-8e89-bc3cfc0be6cc", "71ce38a9-e72d-4209-9c36-cfcf1dbf2519" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b0ccf3d-1ca0-4d3c-8e89-bc3cfc0be6cc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71ce38a9-e72d-4209-9c36-cfcf1dbf2519");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "173adad3-c72d-4aa1-ada9-ef2672cd872c", null, "Doctor", "DOCTOR" },
                    { "271c46e7-4344-4ef3-84e1-f339a1ca5191", null, "Patient", "PATIENT" },
                    { "a88e978a-c6b5-40d0-a187-61b83b8fa145", null, "Nurse", "NURSE" },
                    { "c354e619-63c2-4c41-bb2c-98ab9239ecff", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "Img", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "ccfa8690-5ffe-47cf-8173-9efb8f0cd2ab", 0, null, "3d8262e7-5608-4934-b278-a300cb90fd40", null, new DateTime(2003, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, "Admin", 0, null, "User", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEDY6O4LL9I57+55jK7K6yB8iIZQZUUEmWlrceLUzehVoUEcyTorhvYL7dL65xG6IFA==", null, false, "b1e74f00-9cc9-48e4-aaea-f3466c914bd7", false, "admin@admin.com", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c354e619-63c2-4c41-bb2c-98ab9239ecff", "ccfa8690-5ffe-47cf-8173-9efb8f0cd2ab" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "173adad3-c72d-4aa1-ada9-ef2672cd872c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "271c46e7-4344-4ef3-84e1-f339a1ca5191");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a88e978a-c6b5-40d0-a187-61b83b8fa145");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c354e619-63c2-4c41-bb2c-98ab9239ecff", "ccfa8690-5ffe-47cf-8173-9efb8f0cd2ab" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c354e619-63c2-4c41-bb2c-98ab9239ecff");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ccfa8690-5ffe-47cf-8173-9efb8f0cd2ab");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "188c2140-dfb7-4802-97ea-f13d49201bb8", null, "Patient", "PATIENT" },
                    { "3ad342de-f79b-454c-ab2d-4c340250a560", null, "Nurse", "NURSE" },
                    { "5b0ccf3d-1ca0-4d3c-8e89-bc3cfc0be6cc", null, "Admin", "ADMIN" },
                    { "c41d5cc4-6b53-4d58-86c7-13dfce079b2a", null, "Doctor", "DOCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "Img", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "71ce38a9-e72d-4209-9c36-cfcf1dbf2519", 0, null, "4af67a64-bbe1-4d79-98f1-83f9da8a5b9b", null, new DateTime(2003, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, "Admin", 0, null, "User", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEMt94JbZ4FwfnI/ymddD2wvPyTw7693hWLBeco9ypraN2TuOgTewhz0hv1F/f4keGA==", null, false, "ac551d82-b912-48e0-861f-ba55c6ab0957", false, "admin@admin.com", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5b0ccf3d-1ca0-4d3c-8e89-bc3cfc0be6cc", "71ce38a9-e72d-4209-9c36-cfcf1dbf2519" });
        }
    }
}
