using System;
using System.ComponentModel.DataAnnotations;

namespace AplicatieFitness.Models
{
    public class Programare
    {
        public int ID { get; set; }

        [Required]
        public int MembruID { get; set; }

        [Required]
        public int SesiuneID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataProgramare { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public Membru Membru { get; set; }
        public Sesiune Sesiune { get; set; }
    }
}
