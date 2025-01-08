namespace AplicatieFitness.Models
{
    public class Sesiune
    {
        public int SesiuneId { get; set; }
        public string Tip { get; set; }
        public int AntrenorId { get; set; }
        public string Descriere { get; set; }

        public Antrenor Antrenor { get; set; }
    }
}
