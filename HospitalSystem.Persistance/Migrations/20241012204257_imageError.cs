using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalSystem.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class imageError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e14a056-2123-4ba6-be2f-623b83e16329");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4c99ded-6d34-4065-a007-fe4dac2686c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c07acf4a-8842-4be2-9eb4-5864c4458d6e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c5d1181b-5a74-4abb-a443-b3b997344dbc", "7c85954a-76fe-4461-ae7d-b660cb346ec7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5d1181b-5a74-4abb-a443-b3b997344dbc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c85954a-76fe-4461-ae7d-b660cb346ec7");

            migrationBuilder.CreateTable(
                name: "feedbacks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateFeedback = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_feedbacks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "163ca19f-5389-4c33-9bcf-d15f6d155009", null, "Patient", "PATIENT" },
                    { "3c5644e5-3580-4b3d-a380-a00ac9216d0e", null, "Admin", "ADMIN" },
                    { "62b047f3-0d96-4db1-aaa1-6c93c8761eaa", null, "Nurse", "NURSE" },
                    { "daf27eb5-b32b-4a61-8af2-bd596ace159c", null, "Doctor", "DOCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "Img", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "73dc0bbd-5823-43d4-b57e-922660cea7a0", 0, null, "52952f96-2c01-4679-ae2b-f87ff85a81fa", null, new DateTime(2003, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, "Admin", 0, null, "User", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEPfp9yFT+1WAzWjDjGlSwNWWjjI79+jidVrEKAM6Sib/Pbh2GsOuvaGyQdovwutCmQ==", null, false, "6d0f91f4-f977-46ce-b8d9-44886b204bdf", false, "admin@admin.com", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3c5644e5-3580-4b3d-a380-a00ac9216d0e", "73dc0bbd-5823-43d4-b57e-922660cea7a0" });

            migrationBuilder.CreateIndex(
                name: "IX_feedbacks_UserId",
                table: "feedbacks",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feedbacks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "163ca19f-5389-4c33-9bcf-d15f6d155009");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62b047f3-0d96-4db1-aaa1-6c93c8761eaa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "daf27eb5-b32b-4a61-8af2-bd596ace159c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3c5644e5-3580-4b3d-a380-a00ac9216d0e", "73dc0bbd-5823-43d4-b57e-922660cea7a0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c5644e5-3580-4b3d-a380-a00ac9216d0e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "73dc0bbd-5823-43d4-b57e-922660cea7a0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8e14a056-2123-4ba6-be2f-623b83e16329", null, "Patient", "PATIENT" },
                    { "a4c99ded-6d34-4065-a007-fe4dac2686c3", null, "Doctor", "DOCTOR" },
                    { "c07acf4a-8842-4be2-9eb4-5864c4458d6e", null, "Nurse", "NURSE" },
                    { "c5d1181b-5a74-4abb-a443-b3b997344dbc", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "Img", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "7c85954a-76fe-4461-ae7d-b660cb346ec7", 0, null, "3a06eef8-9470-4aa6-9ae5-ea75e3b9cdab", null, new DateTime(2003, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, "Admin", 0, null, "User", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAENvCtDxhAh/FTbLw8z48PGp2+GKOiuILfcwXGPxE6S8iMgU27NEwxPV+ukS/vyvrJA==", null, false, "0c058c17-fa87-4973-a452-cf2efc26ec3f", false, "admin@admin.com", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c5d1181b-5a74-4abb-a443-b3b997344dbc", "7c85954a-76fe-4461-ae7d-b660cb346ec7" });
        }
    }
}
