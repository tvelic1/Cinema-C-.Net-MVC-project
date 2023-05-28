using System.ComponentModel.DataAnnotations;

namespace OOAD_G6_najjaci_tim.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }

        public string Ime { get; set; }

        public Zanr Zanr { get; set; }

        public int Trajanje { get; set; }

        public int Ocjena { get; set; }

        public Film() { }
    }
}
