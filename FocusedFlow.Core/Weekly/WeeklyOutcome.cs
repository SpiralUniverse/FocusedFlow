using System.Diagnostics.CodeAnalysis;

namespace FocusedFlow.Core.Weekly;

public sealed class WeeklyOutcome
{
    public DateOnly WeekStart { get; }
    public DateOnly WeekEnd { get; }

    public int TotalDays { get; }
    public int PassedDays { get; }
    public double ConsistencyRate { get; }


    public double AverageSleepHours { get; }
    public double AverageWaterLiters { get; }
    public double AverageMealsCount { get; }

    public WeeklyOutcome(
        DateOnly weekStart,
        DateOnly weekEnd,
        int totalDays,
        int passedDays,
        double avgSleep,
        double avgWater,
        double avgMeals
    )
    {
        WeekStart = weekStart;
        WeekEnd = weekEnd;
        TotalDays = totalDays;
        PassedDays = passedDays;
        

        ConsistencyRate = totalDays == 0 ? 0 : (double)passedDays / totalDays;

        AverageSleepHours = avgSleep;
        AverageWaterLiters = avgWater;
        AverageMealsCount = avgMeals;
        

    }
}