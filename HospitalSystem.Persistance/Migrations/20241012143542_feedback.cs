using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalSystem.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class feedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "129dc55a-991d-420b-87ce-923001baadf2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b411c37e-77e9-4934-acc8-0066abb936fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfcaaeed-501a-435e-b12d-f9f813ca0d80");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "aec66af4-cce1-44c0-a849-30d8a6acb969", "0888e6a8-6a8d-44b7-81d8-fcf1e1224b4e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aec66af4-cce1-44c0-a849-30d8a6acb969");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0888e6a8-6a8d-44b7-81d8-fcf1e1224b4e");

            migrationBuilder.CreateTable(
                name: "feedbacks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateFeedback = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_feedbacks_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feedbacks");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "129dc55a-991d-420b-87ce-923001baadf2", null, "Doctor", "DOCTOR" },
                    { "aec66af4-cce1-44c0-a849-30d8a6acb969", null, "Admin", "ADMIN" },
                    { "b411c37e-77e9-4934-acc8-0066abb936fd", null, "Patient", "PATIENT" },
                    { "bfcaaeed-501a-435e-b12d-f9f813ca0d80", null, "Nurse", "NURSE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "Img", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "0888e6a8-6a8d-44b7-81d8-fcf1e1224b4e", 0, null, "b472cf23-b4a0-4961-9a30-b01066bf64bb", null, new DateTime(2003, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, "Admin", 0, null, "User", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEIp8+lR9Xpn5ubVjPveJiqIPge0O7ipI3uhkt2QJ9xVGPwnJYSKbRP8fRMgHJ6W8JQ==", null, false, "2053c32b-4355-417b-85f0-fd28b85dd465", false, "admin@admin.com", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "aec66af4-cce1-44c0-a849-30d8a6acb969", "0888e6a8-6a8d-44b7-81d8-fcf1e1224b4e" });
        }
    }
}
