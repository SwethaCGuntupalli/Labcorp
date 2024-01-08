using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Labcorp.API.Models;

/// <summary>
/// Employee Entity
/// </summary>
public abstract class Employee
{
    protected const int WorkDaysInYear = 260;
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public int WorkDays { get; protected set; }
    public float VacationDaysAvailed { get; set;} = 0;
    public float VacationDaysAccumulated { get; protected set; }
    
    public void Work(int daysWorked)
    {
        if (daysWorked <= 0)
            throw new ArgumentException("Invalid number of days worked.");

        WorkDays = CalculateWorkAccumulation(daysWorked);

    }

    public void TakeVacation(float daysTaken)
    {
        if (daysTaken <= 0)
            throw new ArgumentException("Invalid number of vacation days taken.");

        VacationDaysAvailed = (float)Math.Round(CalculateVacationAccumulation(daysTaken), 2);
    }

    protected abstract float CalculateVacationAccumulation(float daysTaken);
    protected abstract int CalculateWorkAccumulation(int daysWorked);

}
class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
    }
}
