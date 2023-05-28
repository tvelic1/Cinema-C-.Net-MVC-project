using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOAD_G6_najjaci_tim.Models
{
    public class Karta
    {
        [Key, ForeignKey("SjedisteUTerminu")]
        public int Id { get; set; }

        [ForeignKey("Korisnik")]
        public int IdKorisnik { get; set; }

        [ForeignKey("Film")]
        public int IdFilm { get; set; }

        [ForeignKey("Rezervacija")]
        public int IdRezervacija { get; set; } = 0;

        public Karta() { }
    }
}
