using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hubert_Michna_w67259.Migrations
{
    public partial class Migracja_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Typ_Wydatku",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typ_Wydatku", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wydatek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa_Wydatku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Typ_Wydatku_Id = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Data_Wydatku = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Waluta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wydatek", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Typ_Wydatku",
                columns: new[] { "Id", "Nazwa" },
                values: new object[] { 1, "Produkty spożywcze" });

            migrationBuilder.InsertData(
                table: "Typ_Wydatku",
                columns: new[] { "Id", "Nazwa" },
                values: new object[] { 2, "Motoryzacja" });

            migrationBuilder.InsertData(
                table: "Typ_Wydatku",
                columns: new[] { "Id", "Nazwa" },
                values: new object[] { 3, "Edukacja" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Typ_Wydatku");

            migrationBuilder.DropTable(
                name: "Wydatek");
        }
    }
}
