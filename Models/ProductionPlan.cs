namespace ProductionPlanner.Models
{
    public class ProductionPlan
    {
        public int Senin { get; set; }
        public int Selasa { get; set; }
        public int Rabu { get; set; }
        public int Kamis { get; set; }
        public int Jumat { get; set; }

        public List<int> ToList() => new() { Senin, Selasa, Rabu, Kamis, Jumat };
    }
}
