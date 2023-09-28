using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class CreatingAuthDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("4b96d24d-a617-4b36-b061-af35939b2452"), "US", "USA", "https://cdn.countryflags.com/thumbs/hawaii/flag-square-250.png" },
                    { new Guid("5c0fed0e-69d3-478d-9995-dad42492e4d0"), "Ind", "India", "https://cdn.countryflags.com/thumbs/india/flag-square-250.png" },
                    { new Guid("8fdc7709-d0bf-4e1b-b4ca-482e55c915f8"), "Eur", "Europe", "Europe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4b96d24d-a617-4b36-b061-af35939b2452"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5c0fed0e-69d3-478d-9995-dad42492e4d0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8fdc7709-d0bf-4e1b-b4ca-482e55c915f8"));

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
    }
}
