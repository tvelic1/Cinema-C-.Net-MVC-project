namespace OOAD_G6_najjaci_tim.Models
{
    public class Karta
    {
        public int ID { get; set; }
        public int IDKorisnik { get; set; }
        public int IDFilm { get; set; }
        public int IDSjedisteUTerminu { get; set; }
        public int IDRezervacija { get; set; } = 0;
    }
}
