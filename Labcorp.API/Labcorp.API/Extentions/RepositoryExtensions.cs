using Labcorp.API.Data;
using Labcorp.API.Repositories;
using Labcorp.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Labcorp.API.Extentions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options=>
        {
            options.UseInMemoryDatabase("EmployeesDB");
        });

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        return services;
    }
}
