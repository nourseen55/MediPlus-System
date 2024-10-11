using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalSystem.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class hours : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e145f86-5ead-42f7-8f4f-3c422b9f3c2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "646b55a9-7c09-4260-8276-25d78c600813");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "962fbc0e-6c25-4295-968a-bf528c6d108a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4fef6139-eda9-4f0f-8acd-02fbe425fff8", "3a3a7b23-630e-4504-8f5a-357b904c4fa5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fef6139-eda9-4f0f-8acd-02fbe425fff8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a3a7b23-630e-4504-8f5a-357b904c4fa5");

            migrationBuilder.CreateTable(
                name: "WorkingHours",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartHour = table.Column<int>(type: "int", nullable: false),
                    EndHour = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingHours_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHours_DoctorId",
                table: "WorkingHours",
                column: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkingHours");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e145f86-5ead-42f7-8f4f-3c422b9f3c2c", null, "Nurse", "NURSE" },
                    { "4fef6139-eda9-4f0f-8acd-02fbe425fff8", null, "Admin", "ADMIN" },
                    { "646b55a9-7c09-4260-8276-25d78c600813", null, "Doctor", "DOCTOR" },
                    { "962fbc0e-6c25-4295-968a-bf528c6d108a", null, "Patient", "PATIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "Img", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[] { "3a3a7b23-630e-4504-8f5a-357b904c4fa5", 0, null, "05695c86-3c66-4886-95a5-4ee95c008113", null, new DateTime(2003, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, "Admin", 0, null, "User", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEL+pZ3UyD9CS7Aiwe5jRNFcvTSlLE6FaldwrWFgTnhmeJ6yfvJyGbYXU83yO/DB7Mw==", null, false, "2fd7987e-3c2b-4ca8-a69e-d2aa16122499", false, "admin@admin.com", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4fef6139-eda9-4f0f-8acd-02fbe425fff8", "3a3a7b23-630e-4504-8f5a-357b904c4fa5" });
        }
    }
}
