using Labcorp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labcorp.API.Data;

public static class SeedData
{
    public async static Task Initialize(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DataContext>();

        if (await context.Employees.AnyAsync()) return;

        // Seed test employees
        context.Employees.AddRange(
                new HourlyEmployee { FirstName = "John", LastName = "Doe"},
                new HourlyEmployee { FirstName = "Alice", LastName = "Williams"},
                new HourlyEmployee { FirstName = "Eva", LastName = "Clark"},
                new HourlyEmployee { FirstName = "Henry", LastName = "Garcia"},
                new HourlyEmployee { FirstName = "Hanry", LastName = "Jack"},
                new HourlyEmployee { FirstName = "James", LastName = "Williams"},
                new HourlyEmployee { FirstName = "Oliver", LastName = "Noah"},
                new HourlyEmployee { FirstName = "Alexander", LastName = "Carter"},
                new HourlyEmployee { FirstName = "George", LastName = "Doe"},
                new HourlyEmployee { FirstName = "Michael", LastName = "Arthur"},               


                new Manager { FirstName = "David", LastName = "Jones"},
                new Manager { FirstName = "Bob", LastName = "Johnson"},
                new Manager { FirstName = "Grace", LastName = "Davis"},
                new Manager { FirstName = "Robert", LastName = "Liam"},
                new Manager { FirstName = "Leo", LastName = "Adam"},
                new Manager { FirstName = "Charles", LastName = "Anthony"},
                new Manager { FirstName = "Andrew", LastName = "Jones"},
                new Manager { FirstName = "Bob", LastName = "Johnson"},
                new Manager { FirstName = "Michael", LastName = "Alexander"},
                new Manager { FirstName = "Archie", LastName = "Davis"},


                new SalariedEmployee { FirstName = "Jane", LastName = "Smith"},
                new SalariedEmployee { FirstName = "Charlie", LastName = "Brown"},
                new SalariedEmployee { FirstName = "Frank", LastName = "Miller"},
                new SalariedEmployee { FirstName = "Theodore", LastName = "Smith"},
                new SalariedEmployee { FirstName = "Adam", LastName = "Brown"},
                new SalariedEmployee { FirstName = "Benjamin", LastName = "Leo"},
                new SalariedEmployee { FirstName = "Andrew", LastName = "Williams"},
                new SalariedEmployee { FirstName = "Henry", LastName = "Arthur"},
                new SalariedEmployee { FirstName = "Leo", LastName = "John"},
                new SalariedEmployee { FirstName = "Josh", LastName = "Burmaster"}
                

            );

        await context.SaveChangesAsync();

        
    }
}
