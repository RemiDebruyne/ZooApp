using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ZooAPI.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric(37,2)", precision: 37, scale: 2, nullable: true),
                    Size = table.Column<decimal>(type: "numeric(37,2)", precision: 37, scale: 2, nullable: true),
                    Color = table.Column<string>(type: "text", nullable: true),
                    Family = table.Column<int>(type: "integer", nullable: false),
                    Species = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "Color", "Family", "Name", "Size", "Species", "Weight" },
                values: new object[,]
                {
                    { 1, 12, "Dark grey", 2, "Balou", null, 2, null },
                    { 2, 10, "Orange", 0, "Tigrou", null, 0, null },
                    { 3, 37, "Brown", 1, "USA", null, 4, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");
        }
    }
}
