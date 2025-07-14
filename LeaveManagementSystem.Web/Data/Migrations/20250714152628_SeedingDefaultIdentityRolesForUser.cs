using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultIdentityRolesForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "215FCB49-0B60-447E-850A-A15CCACF987D", null, "Employee", "EMPLOYEE" },
                    { "D4A791BF-5E5E-4C50-9349-81B267418952", null, "Supervisor", "SUPERVISOR" },
                    { "FDEB3D96-C44B-49D7-A33D-93487FADE4F5", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "C8E52E08-1D08-44DF-AE74-10E26E1B39E9", 0, "3c822715-22c0-4f90-a340-85f885743b22", "admin@domain.com", true, false, null, "ADMIN@DOMAIN.COM", "ADMIN@DOMAIN.COM", "AQAAAAIAAYagAAAAEM7tns6uaBOnBSbAHPyjyrLak5Jleszxti7Zf5msXR2Oz+tWhhIjfxqBU4tBWu/vkg==", null, false, "8d74a70d-1711-4511-b5df-2796359f7fc9", false, "admin@domain.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "FDEB3D96-C44B-49D7-A33D-93487FADE4F5", "C8E52E08-1D08-44DF-AE74-10E26E1B39E9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "215FCB49-0B60-447E-850A-A15CCACF987D");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D4A791BF-5E5E-4C50-9349-81B267418952");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "FDEB3D96-C44B-49D7-A33D-93487FADE4F5", "C8E52E08-1D08-44DF-AE74-10E26E1B39E9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "FDEB3D96-C44B-49D7-A33D-93487FADE4F5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C8E52E08-1D08-44DF-AE74-10E26E1B39E9");
        }
    }
}
