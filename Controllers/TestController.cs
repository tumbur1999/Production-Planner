using Microsoft.AspNetCore.Mvc;
using ProductionPlanner.TestData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductionPlanner.Controllers
{
  public class TestController : Controller
  {
    [Route("Test/Task2")]
    public IActionResult Task2TestCases()
    {
      return View(TestData.Task2TestCases.Cases);
    }

    [HttpPost]
    [Route("Test/RunTask2Test")]
    public IActionResult RunTask2Test(int testCaseIndex)
    {
      if (testCaseIndex < 0 || testCaseIndex >= TestData.Task2TestCases.Cases.Count)
      {
        TempData["Error"] = "Test case tidak ditemukan!";
        return RedirectToAction("Task2TestCases");
      }

      var testCase = TestData.Task2TestCases.Cases[testCaseIndex];

      // Redirect ke Task2 dengan data pre-filled
      return RedirectToAction("Task2", "Home", new
      {
        senin = testCase.Senin,
        selasa = testCase.Selasa,
        rabu = testCase.Rabu,
        kamis = testCase.Kamis,
        jumat = testCase.Jumat,
        sabtu = testCase.Sabtu,
        minggu = testCase.Minggu
      });
    }

    [HttpPost]
    [Route("Test/RunAllTask2Tests")]
    public IActionResult RunAllTask2Tests()
    {
      var results = new List<TestResult>();

      foreach (var testCase in TestData.Task2TestCases.Cases)
      {
        var result = new TestResult
        {
          TestCase = testCase,
          OriginalPlan = new[] {
                        testCase.Senin, testCase.Selasa, testCase.Rabu,
                        testCase.Kamis, testCase.Jumat, testCase.Sabtu, testCase.Minggu
                    },
          ImprovedPlan = CalculateImprovedPlan(testCase),
          IsCorrect = false
        };

        // Check if total is maintained
        result.IsCorrect = result.ImprovedPlan.Sum() == testCase.Total;
        results.Add(result);
      }

      return View("TestResults", results);
    }

    private int[] CalculateImprovedPlan(Task2TestCase testCase)
    {
      try
      {
        int[] originalPlan = {
                    testCase.Senin, testCase.Selasa, testCase.Rabu,
                    testCase.Kamis, testCase.Jumat, testCase.Sabtu, testCase.Minggu
                };

        // Hitung hari kerja (nilai > 0)
        int workingDays = originalPlan.Count(x => x > 0);

        if (workingDays == 0)
        {
          return new int[7]; // All zeros
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

        return improvedPlan;
      }
      catch (Exception)
      {
        // Return original plan if calculation fails
        return new[] {
                    testCase.Senin, testCase.Selasa, testCase.Rabu,
                    testCase.Kamis, testCase.Jumat, testCase.Sabtu, testCase.Minggu
                };
      }
    }

    [Route("Test/AutoFillForm")]
    public IActionResult AutoFillForm()
    {
      return View();
    }

    [HttpPost]
    [Route("Test/SubmitAutoFill")]
    public IActionResult SubmitAutoFill(bool[] selectedCases)
    {
      var selectedTestCases = new List<Task2TestCase>();

      for (int i = 0; i < selectedCases.Length && i < TestData.Task2TestCases.Cases.Count; i++)
      {
        if (selectedCases[i])
        {
          selectedTestCases.Add(TestData.Task2TestCases.Cases[i]);
        }
      }

      ViewBag.SelectedCases = selectedTestCases;
      return View("AutoFillResults", selectedTestCases);
    }
  }

  public class TestResult
  {
    public Task2TestCase? TestCase { get; set; }
    public int[]? OriginalPlan { get; set; }
    public int[]? ImprovedPlan { get; set; }
    public bool IsCorrect { get; set; }
  }
}