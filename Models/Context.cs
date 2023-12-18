using Microsoft.EntityFrameworkCore;
using SurveySystem.ViewModel;

namespace SurveySystem.Models
{
    public class Context:DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<TblKPI> KPIs { get; set; }
        public Context():base()
        { }
        public Context(DbContextOptions options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblKPI>(t => t.Property(a => a.MeasurementUnit).HasColumnType("Bit"));
        }
        public DbSet<SurveySystem.ViewModel.KPIVM> KPIVM { get; set; } = default!;
    }
}
