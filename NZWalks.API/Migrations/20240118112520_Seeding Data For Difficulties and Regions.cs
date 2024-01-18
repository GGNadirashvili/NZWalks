using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Difficulties_WalkDifficultyId",
                table: "Walks");

            migrationBuilder.DropIndex(
                name: "IX_Walks_WalkDifficultyId",
                table: "Walks");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Difficulties",
                newName: "Name");

            migrationBuilder.AddColumn<Guid>(
                name: "DifficultyId",
                table: "Walks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2ad0bbc3-e76d-41ea-9c89-bc9f0198c8fc"), "Easy" },
                    { new Guid("61de3303-15cb-4174-b198-f0fb7b2987be"), "Medium" },
                    { new Guid("8a4e9d73-7cfe-4ca4-a0dd-72ab99293f22"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Area", "Code", "Lat", "Long", "Name", "Population" },
                values: new object[,]
                {
                    { new Guid("33eeda0b-2a2d-4be9-ab22-bbe06810f9cc"), 0.0, "NSN", 0.0, 0.0, "Nelson", 0L },
                    { new Guid("d3fa0988-920f-4c9a-9143-8f14f3c61e47"), 0.0, "STL", 0.0, 0.0, "Southland", 0L },
                    { new Guid("f9d6a5f4-3efa-4bff-84da-201654a2a6a2"), 0.0, "Akl", 0.0, 0.0, "Auckland", 0L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Walks_DifficultyId",
                table: "Walks",
                column: "DifficultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Difficulties_DifficultyId",
                table: "Walks",
                column: "DifficultyId",
                principalTable: "Difficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Difficulties_DifficultyId",
                table: "Walks");

            migrationBuilder.DropIndex(
                name: "IX_Walks_DifficultyId",
                table: "Walks");

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("2ad0bbc3-e76d-41ea-9c89-bc9f0198c8fc"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("61de3303-15cb-4174-b198-f0fb7b2987be"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("8a4e9d73-7cfe-4ca4-a0dd-72ab99293f22"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("33eeda0b-2a2d-4be9-ab22-bbe06810f9cc"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d3fa0988-920f-4c9a-9143-8f14f3c61e47"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f9d6a5f4-3efa-4bff-84da-201654a2a6a2"));

            migrationBuilder.DropColumn(
                name: "DifficultyId",
                table: "Walks");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Difficulties",
                newName: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Walks_WalkDifficultyId",
                table: "Walks",
                column: "WalkDifficultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Difficulties_WalkDifficultyId",
                table: "Walks",
                column: "WalkDifficultyId",
                principalTable: "Difficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
