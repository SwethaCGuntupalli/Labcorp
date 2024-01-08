using Labcorp.API.Dtos;

namespace Labcorp.API.Services.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetAllEmployessAsync();
    Task<EmployeeDto> GetEmployeeByAsync(int id);
    Task UpdateWorkHoursAsync(int id, int daysWorked);
    Task UpdateVacationHoursAsync(int id, float daysTaken);
}
