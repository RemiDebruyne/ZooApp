﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooAPI.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Family",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Family", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Species_Family_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Family",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(37,2)", precision: 37, scale: 2, nullable: true),
                    Size = table.Column<decimal>(type: "decimal(37,2)", precision: 37, scale: 2, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyId = table.Column<int>(type: "int", nullable: false),
                    SpeciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Family_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Family",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Family",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, null, "Ursidae" });

            migrationBuilder.InsertData(
                table: "Family",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, null, "Felin" });

            migrationBuilder.InsertData(
                table: "Family",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, null, "Avian" });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "FamilyId", "Name" },
                values: new object[,]
                {
                    { 1, 2, "Tiger" },
                    { 2, 2, "Lion" },
                    { 3, 1, "BlackBear" },
                    { 4, 1, "PolarBear" },
                    { 5, 3, "Eagle" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "Color", "FamilyId", "Name", "Size", "SpeciesId", "Weight" },
                values: new object[] { 1, 12, "Dark grey", 1, "Balou", null, 3, null });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "Color", "FamilyId", "Name", "Size", "SpeciesId", "Weight" },
                values: new object[] { 2, 10, "Orange", 2, "Tigrou", null, 1, null });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "Color", "FamilyId", "Name", "Size", "SpeciesId", "Weight" },
                values: new object[] { 3, 37, "Brown body with white head", 3, "Eaglee", null, 5, null });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_FamilyId",
                table: "Animals",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SpeciesId",
                table: "Animals",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Species_FamilyId",
                table: "Species",
                column: "FamilyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Family");
        }
    }
}
