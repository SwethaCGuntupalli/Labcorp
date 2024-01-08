using Labcorp.API.Dtos;
using Labcorp.API.Exceptions;
using Labcorp.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Labcorp.API.Controllers;

/// <summary>
/// Employees Controller
/// </summary>
public class EmployeesController : BaseController
{
    private readonly ILogger<EmployeesController> _logger;
    private readonly IEmployeeService _employeeService;

    // DI Ctor
    public EmployeesController(ILogger<EmployeesController> logger, IEmployeeService employeeService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
    }

    [HttpGet]    
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeesAsync()
    {
        var response = await _employeeService.GetAllEmployessAsync();

        return Ok(response);
    }


    [HttpGet("{id}")]    
    public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
    {
        try
        {
            var response = await _employeeService.GetEmployeeByAsync(id);

            return Ok(response);
        }
        catch(EntityNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }


    [HttpPost("{id}/work")]
    public async Task<IActionResult> WorkAsync(int id, [FromBody] WorkRequestDto workRequest)
    {
        try
        {
            if (workRequest is null) return BadRequest($"WorkRequest is null");

            await _employeeService.UpdateWorkHoursAsync(id, workRequest.Days);

            return Ok();
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("{id}/vacation")]
    public async Task<IActionResult> VacationAsync(int id, [FromBody] VacationRequestDto vacationRequest)
    {
        try
        {
            if (vacationRequest is null) return BadRequest($"VacationRequest is null");

            await _employeeService.UpdateVacationHoursAsync(id, vacationRequest.Days);

            return Ok();
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
