﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOAD_G6_najjaci_tim.Models
{
    public class SjedisteUTerminu
    {
        [Key, ForeignKey("SjedisteUTerminu")]
        public int Id { get; set; }

        [ForeignKey("Sala")]
        public int IdSala { get; set; }

        [ForeignKey("Termin")]
        public int IdTermin { get; set; }

        public int BrojSjedista { get; set; }

        public SjedisteUTerminu() { }
    }
}