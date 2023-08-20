using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class UserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8b6beb91-f777-4d34-b1fb-c58014d942ee", "15715ab0-00d5-4db8-82bb-9be93182c5c9", "User", "user" },
                    { "c6d6e77c-440f-46b8-a7a1-5d222a19524e", "771581d3-58ca-4cdd-be3e-66dba1b4cb19", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b6beb91-f777-4d34-b1fb-c58014d942ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6d6e77c-440f-46b8-a7a1-5d222a19524e");
        }
    }
}
