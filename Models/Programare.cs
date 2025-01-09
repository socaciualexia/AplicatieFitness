using System;
using System.ComponentModel.DataAnnotations;

namespace AplicatieFitness.Models
{
    public class Programare
    {
        public int ProgramareId { get; set; }

        [Required]
        [Display(Name = "Membru")]
        public int MembruId { get; set; }
        public Membru Membru { get; set; }

        [Required]
        [Display(Name = "Sesiune")]
        public int SesiuneId { get; set; }
        public Sesiune Sesiune { get; set; }

        [Required]
        [Display(Name = "Data Programării")]
        public DateTime DataProgramarii { get; set; }
    }
}
