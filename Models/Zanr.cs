using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OOAD_G6_najjaci_tim.Models
{
    public enum Zanr
    {
        [Display(Name = "Horor")]
        Horor,
        [Display(Name = "Romantika")]
        Romantika,
        [Display(Name = "SCIFI")]
        SCIFI,
        [Display(Name = "Dokumentarni")]
        Dokumentarni,
        [Display(Name = "Triler")]
        Triler
    } 

}
