using Labcorp.API.Exceptions;
using System.Reflection.Metadata.Ecma335;

namespace Labcorp.API.Models;

/// <summary>
/// Hourly Employee
/// </summary>
public class HourlyEmployee : Employee
{
    protected const int VacationDaysLimit = 10;
    
    protected override float CalculateVacationAccumulation(float daysTaken)
    {
        float totalDaysTaken = VacationDaysAvailed + daysTaken;
        if ((totalDaysTaken) <= VacationDaysAccumulated)
        {            
            return VacationDaysAvailed + daysTaken;
        }
        else
            throw new VacationExceedeException($"Vacation Days: {daysTaken} exceeded, Available is {Math.Round(VacationDaysAccumulated - VacationDaysAvailed, 2)}");
    }

    protected override int CalculateWorkAccumulation(int daysWorked)
    {
        int totalWorkDays = WorkDays + daysWorked;
        if ((totalWorkDays) <= WorkDaysInYear)
        {
            float proRataLeaves = (totalWorkDays / (float)WorkDaysInYear) * VacationDaysLimit;
            VacationDaysAccumulated = (float)Math.Round(proRataLeaves, 2);

            if (VacationDaysAccumulated > VacationDaysLimit)
                throw new Exception($"Vacation days limit crossed");
            return WorkDays + daysWorked;
        }
        else
            throw new Exception($"Work Days: {daysWorked} exceeded, limit is {WorkDaysInYear}, worked is {WorkDays}");
    }
}
