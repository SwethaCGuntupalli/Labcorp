using Labcorp.API.Dtos;
using Labcorp.API.Exceptions;
using Labcorp.API.Repositories.Interfaces;
using Labcorp.API.Services.Interfaces;

namespace Labcorp.API.Services;

public class EmployeeService : IEmployeeService
{
    private readonly ILogger<EmployeeService> _logger;
    private readonly IEmployeeRepository _repository;

    public EmployeeService(ILogger<EmployeeService> logger, IEmployeeRepository repository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllEmployessAsync()
    {
        var employees = await _repository.GetAllEmployeesAsync();

        if (employees == null || !employees.Any())
        {
            _logger.LogError($"0 Employees found!.");
            return Enumerable.Empty<EmployeeDto>();
        }

        return employees;
    }

    public async Task<EmployeeDto> GetEmployeeByAsync(int id)
    {
        if (id <= 0)
        {
            _logger.LogError($"Requested Employee Id: {id} is out of the range.");
            throw new ArgumentOutOfRangeException(nameof(id));
        }

        var response = await _repository.GetEmployeeByIdAsync(id);

        return response is null ? throw new EntityNotFoundException($"Employee with Id {id} not found.") : response;
    }

    public async Task UpdateVacationHoursAsync(int id, float daysTaken)
    {
        if (id <= 0)
        {
            _logger.LogError($"Requested Employee Id: {id} is out of the range.");
            throw new ArgumentOutOfRangeException(nameof(id));
        }

        if (!await _repository.IsEmployeeExistAsync(id))
        {
            _logger.LogError($"Employee with ID {id} not found.");

            throw new EntityNotFoundException($"Employee with Id {id} not found.");
        }

        await _repository.TakeVacationAsync(id, daysTaken);

    }

    public async Task UpdateWorkHoursAsync(int id, int daysWorked)
    {
        if (id <= 0)
        {
            _logger.LogError($"Requested Employee Id: {id} is out of the range.");
            throw new ArgumentOutOfRangeException(nameof(id));
        }

        if (!await _repository.IsEmployeeExistAsync(id))
        {
            _logger.LogError($"Employee with ID {id} not found.");
            throw new EntityNotFoundException($"Employee with Id {id} not found.");
        }

        await _repository.WorkAsync(id, daysWorked);
    }
}
