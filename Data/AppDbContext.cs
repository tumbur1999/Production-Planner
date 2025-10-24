using Microsoft.EntityFrameworkCore;
using ProductionPlanner.Models;

namespace ProductionPlanner.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ProductionPlan> ProductionPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductionPlan>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.PlanType)
                    .HasDefaultValue("Task2")
                    .HasMaxLength(50);

                // Configure column types for MySQL
                entity.Property(e => e.Senin).HasColumnType("int");
                entity.Property(e => e.Selasa).HasColumnType("int");
                entity.Property(e => e.Rabu).HasColumnType("int");
                entity.Property(e => e.Kamis).HasColumnType("int");
                entity.Property(e => e.Jumat).HasColumnType("int");
                entity.Property(e => e.Sabtu).HasColumnType("int");
                entity.Property(e => e.Minggu).HasColumnType("int");
                entity.Property(e => e.ImprovedSenin).HasColumnType("int");
                entity.Property(e => e.ImprovedSelasa).HasColumnType("int");
                entity.Property(e => e.ImprovedRabu).HasColumnType("int");
                entity.Property(e => e.ImprovedKamis).HasColumnType("int");
                entity.Property(e => e.ImprovedJumat).HasColumnType("int");
                entity.Property(e => e.ImprovedSabtu).HasColumnType("int");
                entity.Property(e => e.ImprovedMinggu).HasColumnType("int");
                entity.Property(e => e.TotalProduction).HasColumnType("int");
                entity.Property(e => e.WorkingDays).HasColumnType("int");
            });
        }
    }
}