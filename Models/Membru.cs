namespace AplicatieFitness.Models
{
    public class Membru
    {
        public int MembruId { get; set; }
        public string Nume { get; set; }
        public string Email { get; set; }
        public int Role { get; set; } // 1 pt admin, 2 pt user
    }
}
