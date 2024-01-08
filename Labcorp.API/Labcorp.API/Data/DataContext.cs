using Labcorp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labcorp.API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    { }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HourlyEmployee>();
        modelBuilder.Entity<SalariedEmployee>();
        modelBuilder.Entity<Manager>();

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());        
                
    }

    
}
