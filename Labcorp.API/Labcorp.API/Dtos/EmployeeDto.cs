namespace Labcorp.API.Dtos;

public class EmployeeDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public float VacationDaysAccumulated { get; set; }
    public float VacationDaysAvailed { get; set; }
    public int WorkDays { get; set; }
    public string Type { get; set; } = default!;
}
