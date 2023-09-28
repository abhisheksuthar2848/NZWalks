using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("06ac1c97-bf44-4b00-9d71-e1a430e33dd6"), "Mediam" },
                    { new Guid("1267e9c6-c2a8-41cc-a713-8a16cadeddae"), "Hard" },
                    { new Guid("da6b05c0-2ab1-4275-a184-3ab2164c0970"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("02197928-aaba-4641-8043-8997bf0b4746"), "US", "USA", "https://cdn.countryflags.com/thumbs/hawaii/flag-square-250.png" },
                    { new Guid("6bb8b247-331c-49f0-9c77-81e13c1fb080"), "Ind", "India", "https://cdn.countryflags.com/thumbs/india/flag-square-250.png" },
                    { new Guid("ae410990-e25b-44b8-a0ae-838a3062c0fc"), "Eur", "Europe", "Europe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("06ac1c97-bf44-4b00-9d71-e1a430e33dd6"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("1267e9c6-c2a8-41cc-a713-8a16cadeddae"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("da6b05c0-2ab1-4275-a184-3ab2164c0970"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("02197928-aaba-4641-8043-8997bf0b4746"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6bb8b247-331c-49f0-9c77-81e13c1fb080"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ae410990-e25b-44b8-a0ae-838a3062c0fc"));
        }
    }
}
