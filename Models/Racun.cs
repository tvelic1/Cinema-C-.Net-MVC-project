using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOAD_G6_najjaci_tim.Models
{
    public class Racun
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("KorisnikSaNalogom")]
        public int IdKorisnikSaNalogom { get; set; }
        public KorisnikSaNalogom KorisnikSaNalogom { get; set; }

        public int BrojRacuna { get; set; }

        public int CSC { get; set; }

        public string DatumIsteka { get; set; }

        public double StanjeRacuna { get; set; }

        public Racun() { }
    }
}
