using Microsoft.AspNetCore.Mvc;
using ProductionPlannerDB.Data;
using ProductionPlannerDB.Models;

namespace ProductionPlannerDB.Controllers
{
    public class PlanningController : Controller
    {
        private readonly AppDbContext _context;

        public PlanningController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(Planning p)
        {
            var input = new[] { p.Senin, p.Selasa, p.Rabu, p.Kamis, p.Jumat, p.Sabtu, p.Minggu };
            var activeDays = input.Where(x => x > 0).ToList(); // hari libur (0) di-skip

            int total = activeDays.Sum();
            int avg = total / activeDays.Count;
            int remainder = total % activeDays.Count;

            // Urutkan hari terbesar untuk sisa pembagian
            var sorted = activeDays
                .Select((val, idx) => new { Day = idx, Value = val })
                .OrderByDescending(x => x.Value)
                .ToList();

            // Hasil awal
            var result = new int[7];
            for (int i = 0; i < 7; i++)
            {
                result[i] = input[i] == 0 ? 0 : avg;
            }

            // Tambah remainder ke hari dengan produksi tertinggi
            for (int i = 0; i < remainder; i++)
            {
                int index = Array.IndexOf(input, sorted[i].Value);
                result[index]++;
            }

            // Simpan ke database
            p.Result = string.Join(", ", result);
            p.TotalAwal = total;
            p.TotalAkhir = result.Sum(x => x);
            _context.Plannings.Add(p);
            _context.SaveChanges();

            ViewBag.Result = result;
            ViewBag.TotalAwal = total;
            ViewBag.TotalAkhir = result.Sum(x => x);
            return View("Result");
        }

        public IActionResult List()
        {
            var data = _context.Plannings.OrderByDescending(x => x.CreatedAt).ToList();
            return View(data);
        }
    }
}
