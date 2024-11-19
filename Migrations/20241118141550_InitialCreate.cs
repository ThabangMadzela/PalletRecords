using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PalletRecords.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(type: "TEXT", nullable: false),
                    InputDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Weight = table.Column<double>(type: "REAL", nullable: false),
                    Material = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    NumberOfItems = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pallets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PalletConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Weight = table.Column<double>(type: "REAL", nullable: false),
                    PalletId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalletConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PalletConfigs_Pallets_PalletId",
                        column: x => x.PalletId,
                        principalTable: "Pallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PalletConfigs_PalletId",
                table: "PalletConfigs",
                column: "PalletId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PalletConfigs");

            migrationBuilder.DropTable(
                name: "Pallets");
        }
    }
}
