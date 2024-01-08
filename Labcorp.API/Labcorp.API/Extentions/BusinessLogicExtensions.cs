using Labcorp.API.Profiles;
using Labcorp.API.Services;
using Labcorp.API.Services.Interfaces;

namespace Labcorp.API.Extentions;

public static class BusinessLogicExtensions
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {

        // AutoMapper and profiles
        services.AddAutoMapper(typeof(EmployeeProfile));

        // Services
        services.AddScoped<IEmployeeService, EmployeeService>();

        // Logging
        services.AddLogging(options =>
        {
            options.AddConsole();
            options.AddDebug();
        });

        return services;
    }
}
