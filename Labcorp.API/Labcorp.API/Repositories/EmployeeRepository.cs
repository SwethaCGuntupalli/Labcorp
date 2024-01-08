using AutoMapper;
using Labcorp.API.Data;
using Labcorp.API.Dtos;
using Labcorp.API.Exceptions;
using Labcorp.API.Models;
using Labcorp.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Labcorp.API.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public EmployeeRepository(DataContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
    {
        var employees = await _context.Employees
            //.Include(x=> x.EmployeeType)
            .ToListAsync();

        return _mapper.Map<IEnumerable<EmployeeDto>>(employees);

    }

    public async Task<EmployeeDto> GetEmployeeByIdAsync(int employeeId)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(x=> x.Id == employeeId);

        return _mapper.Map<EmployeeDto>(employee);       
    }

    public async Task WorkAsync(int employeeId, int daysWorked)
    {
        //var employee = await _context.Employees.FindAsync(employeeId) ?? throw new EntityNotFoundException($"Employee with ID {employeeId} not found.");
        var employee = await _context
            .Employees
            .AsNoTracking()
            //.Include(e => e.EmployeeType)
            .Where(e => e.Id == employeeId)
            .FirstAsync();


        employee.Work(daysWorked);
        _context.Update(employee);        
        await _context.SaveChangesAsync();
    }

    public async Task TakeVacationAsync(int employeeId, float daysTaken)
    {
        //var employee = await _context.Employees.FindAsync(employeeId) ?? throw new EntityNotFoundException($"Employee with ID {employeeId} not found.");
        
        var employee = await _context
            .Employees
            .AsNoTracking()
            //.Include(e => e.EmployeeType)
            .Where(e => e.Id == employeeId)
            .FirstAsync();

        employee.TakeVacation(daysTaken);
        _context.Update(employee);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsEmployeeExistAsync(int employeeId)
    {
        return await _context.Employees.AnyAsync(x=> x.Id == employeeId);
    }
}
