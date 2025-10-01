using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Konyvtar.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Author = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ISBN = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    PublishedYear = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    InStock = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CreatedAt", "ISBN", "InStock", "Price", "PublishedYear", "Title" },
                values: new object[,]
                {
                    { 1, "Gárdonyi Géza", new DateTime(2025, 9, 30, 20, 51, 26, 88, DateTimeKind.Utc).AddTicks(2347), "1234567890123", true, 3500.00m, 1901, "Egri csillagok" },
                    { 2, "Molnár Ferenc", new DateTime(2025, 9, 30, 20, 51, 26, 88, DateTimeKind.Utc).AddTicks(2350), "9876543210987", true, 2800.50m, 1907, "A Pál utcai fiúk" },
                    { 3, "Madách Imre", new DateTime(2025, 9, 30, 20, 51, 26, 88, DateTimeKind.Utc).AddTicks(2351), "4567891234567", false, 4200.75m, 1861, "Az ember tragédiája" },
                    { 4, "Fekete István", new DateTime(2025, 9, 30, 20, 51, 26, 88, DateTimeKind.Utc).AddTicks(2353), "3216549870123", true, 3100.00m, 1957, "Tüskevár" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_ISBN",
                table: "Books",
                column: "ISBN",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
