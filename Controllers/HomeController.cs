using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductionPlanner.Models;

namespace ProductionPlanner.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Result(ProductionPlan plan)
        {
            var original = plan.ToList();
            int total = original.Sum();
            int avg = total / 5;
            int remainder = total % 5;

            // Urutkan hari berdasarkan nilai terbesar untuk alokasi sisa
            var sortedDays = original
                .Select((val, idx) => new { Day = idx, Value = val })
                .OrderByDescending(x => x.Value)
                .ToList();

            // Hasil awal semua = avg
            int[] result = Enumerable.Repeat(avg, 5).ToArray();

            // Bagi sisa ke hari dengan nilai terbesar
            for (int i = 0; i < remainder; i++)
            {
                result[sortedDays[i].Day]++;
            }

            ViewBag.Original = original;
            ViewBag.Result = result;
            ViewBag.Total = total;
            return View();
        }
    }
}
