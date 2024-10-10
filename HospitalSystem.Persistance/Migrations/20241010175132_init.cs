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
                    { "a6470bb7-3634-4f9e-9b05-4d0abd36edc4", null, "Doctor", "DOCTOR" },
                    { "c9edebeb-d09c-4656-afd9-3e5d8d10438b", null, "Patient", "PATIENT" },
                    { "e24d9d68-ba60-4de6-a959-856bbd3aaa05", null, "Nurse", "NURSE" },
                    { "e96ddc09-9f86-478a-9560-051e9cefd261", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "Img", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "6b40f393-6c32-48da-ae91-a42037dc9f7a", 0, null, "facfdffb-d3da-458b-8270-3fd704933991", null, new DateTime(2003, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, "Admin", 0, null, "User", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEKuTNGi4U+1OBLrOStv8TC+92cPkz/cB0cAe4Yv8L1cOK6bXOzxpXpQmnRpyRJ1w1A==", null, false, "7e979741-b9ce-4dfa-9804-bbd58b8ff4cb", false, "admin@admin.com", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e96ddc09-9f86-478a-9560-051e9cefd261", "6b40f393-6c32-48da-ae91-a42037dc9f7a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6470bb7-3634-4f9e-9b05-4d0abd36edc4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9edebeb-d09c-4656-afd9-3e5d8d10438b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e24d9d68-ba60-4de6-a959-856bbd3aaa05");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e96ddc09-9f86-478a-9560-051e9cefd261", "6b40f393-6c32-48da-ae91-a42037dc9f7a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e96ddc09-9f86-478a-9560-051e9cefd261");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b40f393-6c32-48da-ae91-a42037dc9f7a");

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
