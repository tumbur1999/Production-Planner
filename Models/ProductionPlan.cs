using System;

namespace ProductionPlanner.Models
{
    public class ProductionPlan
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Senin { get; set; }
        public int Selasa { get; set; }
        public int Rabu { get; set; }
        public int Kamis { get; set; }
        public int Jumat { get; set; }
        public int Sabtu { get; set; }
        public int Minggu { get; set; }
        public int ImprovedSenin { get; set; }
        public int ImprovedSelasa { get; set; }
        public int ImprovedRabu { get; set; }
        public int ImprovedKamis { get; set; }
        public int ImprovedJumat { get; set; }
        public int ImprovedSabtu { get; set; }
        public int ImprovedMinggu { get; set; }
        public int TotalProduction { get; set; }
        public int WorkingDays { get; set; }
        public string PlanType { get; set; } = "Task2";
    }
}