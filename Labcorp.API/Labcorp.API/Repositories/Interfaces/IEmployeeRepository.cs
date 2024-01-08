using Labcorp.API.Dtos;
using Labcorp.API.Models;

namespace Labcorp.API.Repositories.Interfaces;

public interface IEmployeeRepository
{
    Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
    Task<EmployeeDto> GetEmployeeByIdAsync(int employeeId);
    Task WorkAsync(int employeeId, int daysWorked);
    Task TakeVacationAsync(int employeeId, float daysTaken);
    Task<bool> IsEmployeeExistAsync(int employeeId);
}
