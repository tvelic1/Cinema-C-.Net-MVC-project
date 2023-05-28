using Microsoft.EntityFrameworkCore.Migrations;

namespace OOAD_G6_najjaci_tim.Data.Migrations
{
    public partial class druga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FId",
                table: "Rezervacija",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KId",
                table: "Rezervacija",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_FId",
                table: "Rezervacija",
                column: "FId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KId",
                table: "Rezervacija",
                column: "KId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_Film_FId",
                table: "Rezervacija",
                column: "FId",
                principalTable: "Film",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_KorisnikSaNalogom_KId",
                table: "Rezervacija",
                column: "KId",
                principalTable: "KorisnikSaNalogom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Film_FId",
                table: "Rezervacija");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_KorisnikSaNalogom_KId",
                table: "Rezervacija");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacija_FId",
                table: "Rezervacija");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacija_KId",
                table: "Rezervacija");

            migrationBuilder.DropColumn(
                name: "FId",
                table: "Rezervacija");

            migrationBuilder.DropColumn(
                name: "KId",
                table: "Rezervacija");
        }
    }
}
