﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, new byte[] { 24, 15, 109, 253, 175, 11, 162, 232, 181, 130, 81, 155, 212, 132, 66, 238, 251, 150, 115, 158, 174, 221, 54, 21, 233, 34, 62, 34, 97, 233, 5, 151, 223, 58, 61, 89, 29, 180, 60, 178, 1, 134, 90, 56, 199, 87, 165, 231, 168, 44, 140, 146, 97, 75, 64, 55, 251, 57, 167, 162, 116, 106, 230, 182 }, new byte[] { 219, 219, 233, 65, 51, 95, 187, 230, 136, 11, 174, 243, 31, 92, 152, 107, 103, 179, 204, 205, 159, 20, 243, 181, 182, 216, 163, 182, 25, 20, 49, 221, 19, 41, 101, 101, 99, 165, 110, 120, 139, 9, 76, 195, 69, 118, 13, 133, 4, 172, 73, 246, 197, 92, 52, 67, 204, 6, 192, 104, 250, 141, 159, 45, 141, 207, 52, 178, 172, 206, 184, 117, 12, 87, 5, 48, 80, 43, 189, 228, 85, 38, 25, 55, 33, 140, 121, 227, 88, 222, 18, 32, 197, 39, 159, 92, 110, 98, 90, 121, 227, 234, 185, 169, 111, 51, 35, 245, 121, 192, 123, 59, 181, 228, 95, 141, 33, 230, 33, 237, 103, 24, 251, 157, 96, 112, 90, 185 }, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
