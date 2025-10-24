using Microsoft.EntityFrameworkCore;
using ProductionPlannerDB.Models;

namespace ProductionPlannerDB.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Planning> Plannings { get; set; }
    }
}
