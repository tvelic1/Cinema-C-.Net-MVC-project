using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOAD_G6_najjaci_tim.Models
{
    public class Karta
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("SjedisteUTerminu")]
        public int IdSjedisteUTerminu { get; set; }
        public SjedisteUTerminu SjedisteUTerminu { get; set; }

        [ForeignKey("KorisnikSaNalogom")]
        public int IdKorisnikSaNalogom { get; set; }
        public KorisnikSaNalogom KorisnikSaNalogom { get; set; }

        [ForeignKey("Film")]
        public int IdFilm { get; set; }
        public Film Film { get; set; }

        [ForeignKey("Rezervacija")]
        public int IdRezervacija { get; set; } 
        public Rezervacija Rezervacija { get; set; }

        [ForeignKey("Termin")]
        public int IdTermin { get; set; }
        public Termin Termin { get; set; }

        public Karta() { }
    }
}
