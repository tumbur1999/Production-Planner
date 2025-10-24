using System.Collections.Generic;

namespace ProductionPlanner.TestData
{
  public class Task2TestCase
  {
    public string Name { get; set; } = string.Empty;
    public int Senin { get; set; }
    public int Selasa { get; set; }
    public int Rabu { get; set; }
    public int Kamis { get; set; }
    public int Jumat { get; set; }
    public int Sabtu { get; set; }
    public int Minggu { get; set; }
    public int Total { get; set; }
    public int WorkingDays { get; set; }
    public string Description { get; set; } = string.Empty;
  }

  public static class Task2TestCases
  {
    public static List<Task2TestCase> Cases = new()
        {
            new Task2TestCase
            {
                Name = "Contoh Soal",
                Senin = 4, Selasa = 5, Rabu = 1, Kamis = 7, Jumat = 6, Sabtu = 4, Minggu = 0,
                Total = 27, WorkingDays = 6,
                Description = "Contoh dari soal - Minggu libur"
            },
            new Task2TestCase
            {
                Name = "Weekend Libur",
                Senin = 8, Selasa = 7, Rabu = 6, Kamis = 9, Jumat = 5, Sabtu = 0, Minggu = 0,
                Total = 35, WorkingDays = 5,
                Description = "Sabtu & Minggu libur"
            },
            new Task2TestCase
            {
                Name = "Semua Hari Sama",
                Senin = 5, Selasa = 5, Rabu = 5, Kamis = 5, Jumat = 5, Sabtu = 5, Minggu = 5,
                Total = 35, WorkingDays = 7,
                Description = "Semua hari kerja dengan produksi sama"
            },
            new Task2TestCase
            {
                Name = "Produksi Tinggi Weekend",
                Senin = 3, Selasa = 3, Rabu = 3, Kamis = 3, Jumat = 3, Sabtu = 10, Minggu = 8,
                Total = 33, WorkingDays = 7,
                Description = "Produksi tinggi di akhir minggu"
            },
            new Task2TestCase
            {
                Name = "Hanya Weekend Kerja",
                Senin = 0, Selasa = 0, Rabu = 0, Kamis = 0, Jumat = 0, Sabtu = 15, Minggu = 10,
                Total = 25, WorkingDays = 2,
                Description = "Hanya Sabtu & Minggu kerja"
            },
            new Task2TestCase
            {
                Name = "Variasi Besar",
                Senin = 12, Selasa = 2, Rabu = 8, Kamis = 15, Jumat = 3, Sabtu = 6, Minggu = 0,
                Total = 46, WorkingDays = 6,
                Description = "Variasi produksi besar, Minggu libur"
            },
            new Task2TestCase
            {
                Name = "Produksi Rendah",
                Senin = 2, Selasa = 1, Rabu = 3, Kamis = 2, Jumat = 1, Sabtu = 0, Minggu = 0,
                Total = 9, WorkingDays = 5,
                Description = "Produksi rendah, weekend libur"
            },
            new Task2TestCase
            {
                Name = "Satu Hari Kerja",
                Senin = 0, Selasa = 0, Rabu = 0, Kamis = 20, Jumat = 0, Sabtu = 0, Minggu = 0,
                Total = 20, WorkingDays = 1,
                Description = "Hanya Kamis kerja"
            },
            new Task2TestCase
            {
                Name = "Produksi Sangat Besar",
                Senin = 25, Selasa = 20, Rabu = 30, Kamis = 35, Jumat = 15, Sabtu = 10, Minggu = 5,
                Total = 140, WorkingDays = 7,
                Description = "Produksi sangat besar semua hari"
            },
            new Task2TestCase
            {
                Name = "Pola Selang-seling",
                Senin = 10, Selasa = 0, Rabu = 8, Kamis = 0, Jumat = 12, Sabtu = 0, Minggu = 6,
                Total = 36, WorkingDays = 4,
                Description = "Pola selang-seling hari kerja"
            }
        };
  }
}