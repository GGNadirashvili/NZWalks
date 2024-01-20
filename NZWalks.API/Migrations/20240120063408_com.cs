using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class com : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "Long",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "Population",
                table: "Regions");

            migrationBuilder.RenameColumn(
                name: "Length",
                table: "Walks",
                newName: "LengthInKm");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Walks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WalkImageUrl",
                table: "Walks",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Walks");

            migrationBuilder.DropColumn(
                name: "WalkImageUrl",
                table: "Walks");

            migrationBuilder.RenameColumn(
                name: "LengthInKm",
                table: "Walks",
                newName: "Length");

            migrationBuilder.AddColumn<double>(
                name: "Area",
                table: "Regions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Regions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Long",
                table: "Regions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "Population",
                table: "Regions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("33eeda0b-2a2d-4be9-ab22-bbe06810f9cc"),
                columns: new[] { "Area", "Lat", "Long", "Population" },
                values: new object[] { 0.0, 0.0, 0.0, 0L });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d3fa0988-920f-4c9a-9143-8f14f3c61e47"),
                columns: new[] { "Area", "Lat", "Long", "Population" },
                values: new object[] { 0.0, 0.0, 0.0, 0L });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f9d6a5f4-3efa-4bff-84da-201654a2a6a2"),
                columns: new[] { "Area", "Lat", "Long", "Population" },
                values: new object[] { 0.0, 0.0, 0.0, 0L });
        }
    }
}
