using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalSystem.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e4010d1-dd79-4251-9c1a-71f579f99f2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "620ebcd7-d44d-4428-b27f-07dc08b7d254");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6626ac1f-fe77-4ff6-8e8c-a50f03aa0ab4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "66bd658b-faa3-4207-a753-621ee7678069", "df7e08a4-3d92-47eb-8660-a043222dfce4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66bd658b-faa3-4207-a753-621ee7678069");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df7e08a4-3d92-47eb-8660-a043222dfce4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "3e4010d1-dd79-4251-9c1a-71f579f99f2b", null, "Doctor", "DOCTOR" },
                    { "620ebcd7-d44d-4428-b27f-07dc08b7d254", null, "Nurse", "NURSE" },
                    { "6626ac1f-fe77-4ff6-8e8c-a50f03aa0ab4", null, "Patient", "PATIENT" },
                    { "66bd658b-faa3-4207-a753-621ee7678069", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "Img", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "df7e08a4-3d92-47eb-8660-a043222dfce4", 0, null, "ec499042-5b14-42f5-b54c-9abcf9019fe2", null, new DateTime(2003, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, "Admin", 0, null, "User", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEIZhFx5YNnCLeAnrROhiwP1qkOq0pWiCEOxGgFLgbgXai4DG2tpDX91SL1CM6gw7Vg==", null, false, "128d4c11-d057-4d58-9ac2-ceec0584b10c", false, "admin@admin.com", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "66bd658b-faa3-4207-a753-621ee7678069", "df7e08a4-3d92-47eb-8660-a043222dfce4" });
        }
    }
}
