using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ProductionPlanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // DEFAULT ROUTE: http://localhost:5137/ → Redirect ke Task2
        public IActionResult Index()
        {
            return View("Task2");
        }

        // TASK 1: http://localhost:5137/Task1 (5 hari kerja - TANPA database)
        [Route("Task1")]
        public IActionResult Task1()
        {
            return View();
        }

        // TASK 2: http://localhost:5137/Task2 (7 hari - TANPA database untuk sementara)
        [Route("Task2")]
        public IActionResult Task2()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // PROCESS TASK 1 - 5 HARI KERJA
        [HttpPost]
        [Route("ProcessTask1")]
        public IActionResult ProcessTask1(int senin, int selasa, int rabu, int kamis, int jumat)
        {
            try
            {
                // Data input
                int[] originalPlan = { senin, selasa, rabu, kamis, jumat };
                string[] days = { "Senin", "Selasa", "Rabu", "Kamis", "Jumat" };

                // Validasi: semua hari harus >= 0
                if (originalPlan.Any(x => x < 0))
                {
                    TempData["Error"] = "Nilai produksi tidak boleh negatif!";
                    return RedirectToAction("Task1");
                }

                // Hitung total produksi
                int totalProduction = originalPlan.Sum();

                // Jika total 0, kembalikan semua 0
                if (totalProduction == 0)
                {
                    ViewBag.OriginalPlan = originalPlan;
                    ViewBag.ImprovedPlan = new int[] { 0, 0, 0, 0, 0 };
                    ViewBag.Days = days;
                    ViewBag.TotalProduction = 0;
                    ViewBag.Message = "Total produksi adalah 0, tidak ada yang perlu diperbaiki.";
                    return View("Task1Result");
                }

                // Hitung target per hari (pembulatan ke bawah)
                int targetPerDay = totalProduction / 5;
                int remainder = totalProduction % 5;

                // Buat rencana yang diperbaiki
                int[] improvedPlan = new int[5];

                // Urutkan hari berdasarkan prioritas (nilai tertinggi pertama)
                var dayPriorities = originalPlan
                    .Select((value, index) => new { Value = value, Index = index })
                    .OrderByDescending(x => x.Value)
                    .ThenByDescending(x => x.Index)
                    .ToList();

                // Distribusikan remainder ke hari dengan prioritas tertinggi
                for (int i = 0; i < remainder; i++)
                {
                    improvedPlan[dayPriorities[i].Index] = targetPerDay + 1;
                }

                // Untuk hari lainnya, set ke target per hari
                for (int i = remainder; i < 5; i++)
                {
                    improvedPlan[dayPriorities[i].Index] = targetPerDay;
                }

                // Validasi: total improved plan harus sama dengan original total
                int improvedTotal = improvedPlan.Sum();
                if (improvedTotal != totalProduction)
                {
                    int difference = totalProduction - improvedTotal;
                    if (difference != 0)
                    {
                        improvedPlan[dayPriorities[0].Index] += difference;
                    }
                }

                // Pass data ke view
                ViewBag.OriginalPlan = originalPlan;
                ViewBag.ImprovedPlan = improvedPlan;
                ViewBag.Days = days;
                ViewBag.TotalProduction = totalProduction;
                ViewBag.TargetPerDay = targetPerDay;
                ViewBag.Remainder = remainder;
                ViewBag.Message = "Rencana produksi berhasil diperbaiki dengan distribusi yang merata!";

                return View("Task1Result");
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Terjadi error: {ex.Message}";
                return RedirectToAction("Task1");
            }
        }

        // PROCESS TASK 2 - 7 HARI
        [HttpPost]
        [Route("ProcessTask2")]
        public IActionResult ProcessTask2(int senin, int selasa, int rabu, int kamis, int jumat, int sabtu, int minggu, bool lihatData = false)
        {
            try
            {
                // Data input
                int[] originalPlan = { senin, selasa, rabu, kamis, jumat, sabtu, minggu };
                string[] days = { "Senin", "Selasa", "Rabu", "Kamis", "Jumat", "Sabtu", "Minggu" };

                // Hitung hari kerja (nilai > 0)
                int workingDays = originalPlan.Count(x => x > 0);
                
                if (workingDays == 0)
                {
                    TempData["Error"] = "Minimal harus ada 1 hari kerja!";
                    return RedirectToAction("Task2");
                }

                // Hitung total produksi
                int totalProduction = originalPlan.Sum();

                // Hitung target per hari
                int targetPerDay = totalProduction / workingDays;
                int remainder = totalProduction % workingDays;

                // Buat rencana yang diperbaiki
                int[] improvedPlan = new int[7];
                Array.Copy(originalPlan, improvedPlan, 7);

                // Urutkan hari berdasarkan prioritas (nilai tertinggi pertama, hanya hari kerja)
                var dayPriorities = originalPlan
                    .Select((value, index) => new { Value = value, Index = index, IsWorkingDay = value > 0 })
                    .Where(x => x.IsWorkingDay)
                    .OrderByDescending(x => x.Value)
                    .ThenByDescending(x => x.Index)
                    .ToList();

                // Distribusikan remainder ke hari kerja dengan prioritas tertinggi
                for (int i = 0; i < remainder && i < dayPriorities.Count; i++)
                {
                    improvedPlan[dayPriorities[i].Index] = targetPerDay + 1;
                }

                // Untuk hari kerja lainnya, set ke target per hari
                for (int i = remainder; i < dayPriorities.Count; i++)
                {
                    improvedPlan[dayPriorities[i].Index] = targetPerDay;
                }

                // Hari libur (nilai 0) tetap 0
                for (int i = 0; i < 7; i++)
                {
                    if (originalPlan[i] == 0)
                    {
                        improvedPlan[i] = 0;
                    }
                }

                // Untuk sementara, abaikan parameter lihatData (tidak simpan ke database)
                ViewBag.OriginalPlan = originalPlan;
                ViewBag.ImprovedPlan = improvedPlan;
                ViewBag.Days = days;
                ViewBag.TotalProduction = totalProduction;
                ViewBag.WorkingDays = workingDays;
                ViewBag.LihatData = false; // Selalu false untuk sementara

                return View("Task2Result");
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Terjadi error: {ex.Message}";
                return RedirectToAction("Task2");
            }
        }

        // LIHAT SEMUA DATA - TAMPILAN INFORMASI
        [Route("ViewAllData")]
        public IActionResult ViewAllData()
        {
            return View();
        }
    }
}