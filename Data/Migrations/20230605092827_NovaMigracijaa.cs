using Microsoft.EntityFrameworkCore.Migrations;

namespace OOAD_G6_najjaci_tim.Data.Migrations
{
    public partial class NovaMigracijaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zanr = table.Column<int>(type: "int", nullable: false),
                    Trajanje = table.Column<int>(type: "int", nullable: false),
                    Ocjena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikSistema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRodjenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikSistema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kapacitet = table.Column<int>(type: "int", nullable: false),
                    brojSale = table.Column<int>(type: "int", nullable: false),
                    Je4D = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SjedisteUTerminu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojSjedista = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SjedisteUTerminu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Termin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrijeme = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrator_KorisnikSistema_Id",
                        column: x => x.Id,
                        principalTable: "KorisnikSistema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gost_KorisnikSistema_Id",
                        column: x => x.Id,
                        principalTable: "KorisnikSistema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikSaNalogom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImaPravoNaPopust = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikSaNalogom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KorisnikSaNalogom_KorisnikSistema_Id",
                        column: x => x.Id,
                        principalTable: "KorisnikSistema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Racun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKorisnikSaNalogom = table.Column<int>(type: "int", nullable: false),
                    BrojRacuna = table.Column<int>(type: "int", nullable: false),
                    CSC = table.Column<int>(type: "int", nullable: false),
                    DatumIsteka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StanjeRacuna = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Racun_KorisnikSaNalogom_IdKorisnikSaNalogom",
                        column: x => x.IdKorisnikSaNalogom,
                        principalTable: "KorisnikSaNalogom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKorisnikSaNalogom = table.Column<int>(type: "int", nullable: false),
                    IdFilm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Film_IdFilm",
                        column: x => x.IdFilm,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacija_KorisnikSaNalogom_IdKorisnikSaNalogom",
                        column: x => x.IdKorisnikSaNalogom,
                        principalTable: "KorisnikSaNalogom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Karta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSjedisteUTerminu = table.Column<int>(type: "int", nullable: false),
                    IdKorisnikSaNalogom = table.Column<int>(type: "int", nullable: false),
                    IdFilm = table.Column<int>(type: "int", nullable: false),
                    IdRezervacija = table.Column<int>(type: "int", nullable: false),
                    IdTermin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Karta_Film_IdFilm",
                        column: x => x.IdFilm,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Karta_KorisnikSaNalogom_IdKorisnikSaNalogom",
                        column: x => x.IdKorisnikSaNalogom,
                        principalTable: "KorisnikSaNalogom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Karta_Rezervacija_IdRezervacija",
                        column: x => x.IdRezervacija,
                        principalTable: "Rezervacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Karta_SjedisteUTerminu_IdSjedisteUTerminu",
                        column: x => x.IdSjedisteUTerminu,
                        principalTable: "SjedisteUTerminu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Karta_Termin_IdTermin",
                        column: x => x.IdTermin,
                        principalTable: "Termin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Karta_IdFilm",
                table: "Karta",
                column: "IdFilm");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_IdKorisnikSaNalogom",
                table: "Karta",
                column: "IdKorisnikSaNalogom");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_IdRezervacija",
                table: "Karta",
                column: "IdRezervacija");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_IdSjedisteUTerminu",
                table: "Karta",
                column: "IdSjedisteUTerminu");

            migrationBuilder.CreateIndex(
                name: "IX_Karta_IdTermin",
                table: "Karta",
                column: "IdTermin");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_IdKorisnikSaNalogom",
                table: "Racun",
                column: "IdKorisnikSaNalogom");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_IdFilm",
                table: "Rezervacija",
                column: "IdFilm");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_IdKorisnikSaNalogom",
                table: "Rezervacija",
                column: "IdKorisnikSaNalogom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "Gost");

            migrationBuilder.DropTable(
                name: "Karta");

            migrationBuilder.DropTable(
                name: "Racun");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "SjedisteUTerminu");

            migrationBuilder.DropTable(
                name: "Termin");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "KorisnikSaNalogom");

            migrationBuilder.DropTable(
                name: "KorisnikSistema");
        }
    }
}
