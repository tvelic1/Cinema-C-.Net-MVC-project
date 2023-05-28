using System.ComponentModel.DataAnnotations;

namespace OOAD_G6_najjaci_tim.Models
{
    public class Racun
    {
        [Key]
        public int Id { get; set; }
        public int BrojRacuna { get; set; }
        public int CSC { get; set; }
        public string DatumIsteka { get; set; }
        public double StanjeRacuna { get; set; }

        public Racun() { }
    }
}
