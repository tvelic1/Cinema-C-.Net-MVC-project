using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOAD_G6_najjaci_tim.Models
{
    public class Karta
    {
        [Key]
        public int Id { get; set; }
        public int IdKorisnik { get; set; }
        [ForeignKey("Film")]
        public int IdFilm { get; set; }
        [ForeignKey("SjedisteUTerminu")]
        public int IdSjedisteUTerminu { get; set; }
        [ForeignKey("Rezervacija")]
        public int IdRezervacija { get; set; } = 0;

        public Karta() { }
    }
}
