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
                keyValue: "610f5752-ddc7-4c99-bfaa-076b604ba0a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6685d69-8bb2-4df0-b5f0-7a2d2844116e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfc7dbd4-97be-4e96-8cc2-65d8fdd8564a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e58fafed-bd65-4b51-8fbf-b056071aee63", "2a58b05e-7df9-49c9-8d84-7406d2b311c8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e58fafed-bd65-4b51-8fbf-b056071aee63");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a58b05e-7df9-49c9-8d84-7406d2b311c8");

            migrationBuilder.CreateTable(
                name: "NewsPosts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PostImg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsPosts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_NewsPosts_UserId",
                table: "NewsPosts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsPosts");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "610f5752-ddc7-4c99-bfaa-076b604ba0a4", null, "Nurse", "NURSE" },
                    { "b6685d69-8bb2-4df0-b5f0-7a2d2844116e", null, "Doctor", "DOCTOR" },
                    { "cfc7dbd4-97be-4e96-8cc2-65d8fdd8564a", null, "Patient", "PATIENT" },
                    { "e58fafed-bd65-4b51-8fbf-b056071aee63", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "Img", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "2a58b05e-7df9-49c9-8d84-7406d2b311c8", 0, null, "62304197-8d3c-4fe7-a527-6d7ff59872e7", null, new DateTime(2003, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, "Admin", 0, null, "User", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEJOd3dm7QcMGEBXN0as9R9VIe+uFfDlKD5kkLSLm4pQ+OoAX7n7g8uP3e5K+hukpsg==", null, false, "f079002e-71d4-4361-91ea-0fd763aa1341", false, "admin@admin.com", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e58fafed-bd65-4b51-8fbf-b056071aee63", "2a58b05e-7df9-49c9-8d84-7406d2b311c8" });
        }
    }
}
