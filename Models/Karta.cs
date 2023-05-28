using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOAD_G6_najjaci_tim.Models
{
    public class Karta
    {
        [Key, ForeignKey("SjedisteUTerminu")]
        public int Id { get; set; }
        public SjedisteUTerminu SjedisteUTerminu { get; set; }

        [ForeignKey("KorisnikSaNalogom")]
        public int IdKorisnikSaNalogom { get; set; }
        public KorisnikSaNalogom KorisnikSaNalogom { get; set; }

        [ForeignKey("Film")]
        public int IdFilm { get; set; }
        public Film Film { get; set; }

        [ForeignKey("Rezervacija")]
        public int IdRezervacija { get; set; } = 0;
        public Rezervacija Rezervacija { get; set; }


        public Karta() { }
    }
}
