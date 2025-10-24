using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductionPlanner.Models
{
    public class ProductionPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Senin { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Selasa { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Rabu { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Kamis { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Jumat { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Sabtu { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Minggu { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int ImprovedSenin { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int ImprovedSelasa { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int ImprovedRabu { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int ImprovedKamis { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int ImprovedJumat { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int ImprovedSabtu { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int ImprovedMinggu { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int TotalProduction { get; set; }

        [Required]
        [Range(0, 7)]
        public int WorkingDays { get; set; }

        [Required]
        [StringLength(50)]
        public string PlanType { get; set; } = "Task2";
    }
}