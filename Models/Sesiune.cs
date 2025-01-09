using System;
using System.ComponentModel.DataAnnotations;

namespace AplicatieFitness.Models
{
    public class Sesiune
    {
        public int SesiuneId { get; set; }

        [Required]
        [Display(Name = "Tip Sesiune")]
        public string Tip { get; set; }

        [Required]
        [Display(Name = "Antrenor")]
        public int AntrenorId { get; set; }

        [Required]
        [Display(Name = "Membru")]
        public int MembruId { get; set; }

        [Required]
        [Display(Name = "Data și Ora")]
        public DateTime DataOra { get; set; }
    }
}