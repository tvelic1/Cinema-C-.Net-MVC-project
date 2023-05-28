using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOAD_G6_najjaci_tim.Models
{
    public class KorisnikSaNalogom : KorisnikSistema
    {
       

        public string Password { get; set; }

        public string Email { get; set; }

        public bool ImaPravoNaPopust { get; set; }

        public KorisnikSaNalogom() { }
    }
}
