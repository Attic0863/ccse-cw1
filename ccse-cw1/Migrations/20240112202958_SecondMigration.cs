using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ccse_cw1.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "770aae6b-29fd-41db-82ac-dd9853d0e47b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2c990dc-7f7d-4e19-ab8b-94b0d1a6847c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa5daf70-ddc8-4c8f-82b0-ab02ec404c8f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "311481e4-fa1f-4481-9b0a-7e2d0647b05c", null, "client", "client" },
                    { "321cbf11-c1ce-4ee8-8378-730da675c60f", null, "seller", "seller" },
                    { "94718124-3692-4851-aba7-4a79c3228adc", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "311481e4-fa1f-4481-9b0a-7e2d0647b05c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "321cbf11-c1ce-4ee8-8378-730da675c60f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94718124-3692-4851-aba7-4a79c3228adc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "770aae6b-29fd-41db-82ac-dd9853d0e47b", null, "admin", "admin" },
                    { "c2c990dc-7f7d-4e19-ab8b-94b0d1a6847c", null, "client", "client" },
                    { "fa5daf70-ddc8-4c8f-82b0-ab02ec404c8f", null, "seller", "seller" }
                });
        }
    }
}
