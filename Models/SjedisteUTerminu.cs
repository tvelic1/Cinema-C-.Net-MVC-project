using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOAD_G6_najjaci_tim.Models
{
    public class SjedisteUTerminu
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Sala")]
        public int IdSala { get; set; }
        public Sala S
        { get; set; }

        [ForeignKey("Termin")]
        public int IdTermin { get; set; }
        public Termin T { get; set; }

        public int BrojSjedista { get; set; }

        public SjedisteUTerminu() { }
    }
}
