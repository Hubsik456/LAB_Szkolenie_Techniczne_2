using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hubert_Michna_w67259.Migrations
{
    public partial class Migracja_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wydatek_Typ_Wydatku_Typ_WydatkuId",
                table: "Wydatek");

            migrationBuilder.DropIndex(
                name: "IX_Wydatek_Typ_WydatkuId",
                table: "Wydatek");

            migrationBuilder.RenameColumn(
                name: "Typ_WydatkuId",
                table: "Wydatek",
                newName: "Typ_Wydatku_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Typ_Wydatku_ID",
                table: "Wydatek",
                newName: "Typ_WydatkuId");

            migrationBuilder.CreateIndex(
                name: "IX_Wydatek_Typ_WydatkuId",
                table: "Wydatek",
                column: "Typ_WydatkuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wydatek_Typ_Wydatku_Typ_WydatkuId",
                table: "Wydatek",
                column: "Typ_WydatkuId",
                principalTable: "Typ_Wydatku",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
