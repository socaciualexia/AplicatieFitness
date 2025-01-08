namespace AplicatieFitness.Models
{
    public class Programare
    {
        public int ProgramareId { get; set; }
        public int MembruId { get; set; }
        public int SesiuneId { get; set; }
        public DateTime DataProgramarii { get; set; }

        public Membru Membru { get; set; }
        public Sesiune Sesiune { get; set; }
    }
}
