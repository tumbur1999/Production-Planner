using System.ComponentModel.DataAnnotations;

namespace ProductionPlannerDB.Models
{
    public class Planning
    {
        [Key]
        public int Id { get; set; }
        public int Senin { get; set; }
        public int Selasa { get; set; }
        public int Rabu { get; set; }
        public int Kamis { get; set; }
        public int Jumat { get; set; }
        public int Sabtu { get; set; }
        public int Minggu { get; set; }

        // Untuk penyimpanan hasil perataan
        public string? Result { get; set; }
        public int TotalAwal { get; set; }
        public int TotalAkhir { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
