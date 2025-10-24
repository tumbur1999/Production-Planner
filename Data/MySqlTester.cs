using Microsoft.EntityFrameworkCore;

namespace ProductionPlanner.Data
{
    public class MySqlTester
    {
        public static async Task TestConnection(AppDbContext context)
        {
            try
            {
                Console.WriteLine("Testing MySQL connection...");

                // Test koneksi
                var canConnect = await context.Database.CanConnectAsync();
                Console.WriteLine($"MySQL Connection: {canConnect}");

                if (canConnect)
                {
                    // Test create record
                    var testRecord = new Models.ProductionPlan
                    {
                        CreatedDate = DateTime.Now,
                        Senin = 1,
                        Selasa = 2,
                        Rabu = 3,
                        Kamis = 4,
                        Jumat = 5,
                        Sabtu = 0,
                        Minggu = 0,
                        ImprovedSenin = 3,
                        ImprovedSelasa = 3,
                        ImprovedRabu = 3,
                        ImprovedKamis = 3,
                        ImprovedJumat = 3,
                        ImprovedSabtu = 0,
                        ImprovedMinggu = 0,
                        TotalProduction = 15,
                        WorkingDays = 5,
                        PlanType = "Test"
                    };

                    context.ProductionPlans.Add(testRecord);
                    await context.SaveChangesAsync();
                    Console.WriteLine("✅ Test record created successfully in MySQL");

                    // Count records
                    var count = await context.ProductionPlans.CountAsync();
                    Console.WriteLine($"✅ Total records in database: {count}");

                    // Clean up test record
                    context.ProductionPlans.Remove(testRecord);
                    await context.SaveChangesAsync();
                    Console.WriteLine("✅ Test record cleaned up");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ MySQL test failed: {ex.Message}");
                Console.WriteLine($"Full error: {ex}");
            }
        }
    }
}