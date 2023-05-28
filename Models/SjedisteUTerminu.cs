using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOAD_G6_najjaci_tim.Models
{
    public class SjedisteUTerminu
    {
        [Key, ForeignKey("Kart")]
        public int Id { get; set; }
        public Karta Karta { get; set; }

        [ForeignKey("Sala")]
        public int IdSala { get; set; }
        public Sala Sala { get; set; }

        [ForeignKey("Termin")]
        public int IdTermin { get; set; }
        public Termin Termin { get; set; }

        public int BrojSjedista { get; set; }

        public SjedisteUTerminu() { }
    }
}
