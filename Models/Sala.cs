using System.ComponentModel.DataAnnotations;

namespace OOAD_G6_najjaci_tim.Models
{
    public class Sala
    {
        [Key]
        public int Id { get; set; }

        public int Kapacitet { get; set; }

        public bool Je4D { get; set; }

        public Sala() { }
    }
}
