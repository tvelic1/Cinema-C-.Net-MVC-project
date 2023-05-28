using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOAD_G6_najjaci_tim.Models
{
    public class Karta
    {
        [Key, ForeignKey("SjedisteUTerminu")]
        public int Id { get; set; }
        public SjedisteUTerminu S
        { get; set; }

        [ForeignKey("KorisnikSaNalogom")]
        public int IdKorisnik { get; set; }
        public KorisnikSaNalogom K
        { get; set; }

        [ForeignKey("Film")]
        public int IdFilm { get; set; }
        public Film film { get; set; }

        [ForeignKey("Rezervacija")]
        public int IdRezervacija { get; set; } = 0;
        public Rezervacija R { get; set; }
                

        public Karta() { }
    }
}
