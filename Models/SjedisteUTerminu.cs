using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOAD_G6_najjaci_tim.Models
{
    public class SjedisteUTerminu
    {
        [Key]
        public int Id { get; set; }
      

        public int BrojSjedista { get; set; }

        public SjedisteUTerminu() { }
    }
}
