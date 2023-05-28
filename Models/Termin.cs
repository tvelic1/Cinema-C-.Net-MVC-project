using System.ComponentModel.DataAnnotations;

namespace OOAD_G6_najjaci_tim.Models
{
    public class Termin
    {
        [Key]
        public int Id { get; set; }

        public string Vrijeme { get; set; }

        public Termin() { }
    }
}
