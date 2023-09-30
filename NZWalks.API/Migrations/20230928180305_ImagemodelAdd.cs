using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class ImagemodelAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileExtenction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("5053ec0a-3e5b-4606-8230-f03be8fb3d74"), "Ind", "India", "https://cdn.countryflags.com/thumbs/india/flag-square-250.png" },
                    { new Guid("8972c2c2-2b91-402d-a248-7f2c34a88ba9"), "Eur", "Europe", "Europe" },
                    { new Guid("eef44ab8-7bf5-4824-8ee8-81c569cdc3b0"), "US", "USA", "https://cdn.countryflags.com/thumbs/hawaii/flag-square-250.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5053ec0a-3e5b-4606-8230-f03be8fb3d74"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8972c2c2-2b91-402d-a248-7f2c34a88ba9"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("eef44ab8-7bf5-4824-8ee8-81c569cdc3b0"));

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
    }
}
