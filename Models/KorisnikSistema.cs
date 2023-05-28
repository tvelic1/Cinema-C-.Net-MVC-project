using System.ComponentModel.DataAnnotations;

namespace OOAD_G6_najjaci_tim.Models
{
    public abstract class KorisnikSistema
    {
        [Key]
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string DateRodjenja { get; set; }
        public int BrojTelefona { get; set; }

        public KorisnikSistema() { }
    }
}
