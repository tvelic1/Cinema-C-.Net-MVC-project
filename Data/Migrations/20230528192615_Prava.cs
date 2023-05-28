using Microsoft.EntityFrameworkCore.Migrations;

namespace OOAD_G6_najjaci_tim.Data.Migrations
{
    public partial class Prava : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SId",
                table: "SjedisteUTerminu",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TId",
                table: "SjedisteUTerminu",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KId",
                table: "Racun",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KId",
                table: "Karta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RId",
                table: "Karta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SId",
                table: "Karta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "filmId",
                table: "Karta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SjedisteUTerminu_SId",
                table: "SjedisteUTerminu",
                column: "SId");

            migrationBuilder.CreateIndex(
                name: "IX_SjedisteUTerminu_TId",
                table: "SjedisteUTerminu",
                column: "TId");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_KId",
                table: "Racun",
                column: "KId");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_filmId",
                table: "Karta",
                column: "filmId");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_KId",
                table: "Karta",
                column: "KId");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_RId",
                table: "Karta",
                column: "RId");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_SId",
                table: "Karta",
                column: "SId");

            migrationBuilder.AddForeignKey(
                name: "FK_Karta_Film_filmId",
                table: "Karta",
                column: "filmId",
                principalTable: "Film",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Karta_KorisnikSaNalogom_KId",
                table: "Karta",
                column: "KId",
                principalTable: "KorisnikSaNalogom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Karta_Rezervacija_RId",
                table: "Karta",
                column: "RId",
                principalTable: "Rezervacija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Karta_SjedisteUTerminu_SId",
                table: "Karta",
                column: "SId",
                principalTable: "SjedisteUTerminu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Racun_KorisnikSaNalogom_KId",
                table: "Racun",
                column: "KId",
                principalTable: "KorisnikSaNalogom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SjedisteUTerminu_Sala_SId",
                table: "SjedisteUTerminu",
                column: "SId",
                principalTable: "Sala",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SjedisteUTerminu_Termin_TId",
                table: "SjedisteUTerminu",
                column: "TId",
                principalTable: "Termin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karta_Film_filmId",
                table: "Karta");

            migrationBuilder.DropForeignKey(
                name: "FK_Karta_KorisnikSaNalogom_KId",
                table: "Karta");

            migrationBuilder.DropForeignKey(
                name: "FK_Karta_Rezervacija_RId",
                table: "Karta");

            migrationBuilder.DropForeignKey(
                name: "FK_Karta_SjedisteUTerminu_SId",
                table: "Karta");

            migrationBuilder.DropForeignKey(
                name: "FK_Racun_KorisnikSaNalogom_KId",
                table: "Racun");

            migrationBuilder.DropForeignKey(
                name: "FK_SjedisteUTerminu_Sala_SId",
                table: "SjedisteUTerminu");

            migrationBuilder.DropForeignKey(
                name: "FK_SjedisteUTerminu_Termin_TId",
                table: "SjedisteUTerminu");

            migrationBuilder.DropIndex(
                name: "IX_SjedisteUTerminu_SId",
                table: "SjedisteUTerminu");

            migrationBuilder.DropIndex(
                name: "IX_SjedisteUTerminu_TId",
                table: "SjedisteUTerminu");

            migrationBuilder.DropIndex(
                name: "IX_Racun_KId",
                table: "Racun");

            migrationBuilder.DropIndex(
                name: "IX_Karta_filmId",
                table: "Karta");

            migrationBuilder.DropIndex(
                name: "IX_Karta_KId",
                table: "Karta");

            migrationBuilder.DropIndex(
                name: "IX_Karta_RId",
                table: "Karta");

            migrationBuilder.DropIndex(
                name: "IX_Karta_SId",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "SId",
                table: "SjedisteUTerminu");

            migrationBuilder.DropColumn(
                name: "TId",
                table: "SjedisteUTerminu");

            migrationBuilder.DropColumn(
                name: "KId",
                table: "Racun");

            migrationBuilder.DropColumn(
                name: "KId",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "RId",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "SId",
                table: "Karta");

            migrationBuilder.DropColumn(
                name: "filmId",
                table: "Karta");
        }
    }
}
