using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C8E52E08-1D08-44DF-AE74-10E26E1B39E9",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7ca82bb-38b4-4652-9079-000b75b3ddad", new DateOnly(2000, 4, 27), "Default", "Admin", "AQAAAAIAAYagAAAAEE8VCscqNxiGant0GkQcknQBbLjkSX8avFIMv8/ehp3j1yQ4p0JKqnvmUsYQnTDY/Q==", "d2a42da1-064c-4446-9cad-8a227d39f746" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C8E52E08-1D08-44DF-AE74-10E26E1B39E9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c822715-22c0-4f90-a340-85f885743b22", "AQAAAAIAAYagAAAAEM7tns6uaBOnBSbAHPyjyrLak5Jleszxti7Zf5msXR2Oz+tWhhIjfxqBU4tBWu/vkg==", "8d74a70d-1711-4511-b5df-2796359f7fc9" });
        }
    }
}
