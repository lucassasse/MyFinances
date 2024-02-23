using Microsoft.EntityFrameworkCore;
using MyFinances.Domain.Models;

namespace MyFinances.Domain.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Bank> Bank { get; set; }
        public DbSet<FinancialTransaction> FinancialTransaction { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>()
               .Property(w => w.Amount)
               .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<FinancialTransaction>()
                .Property(w => w.Value)
                .HasColumnType("decimal(18,2)");
        }

    }
}
