namespace FocusedFlow.Core.Monthly;

public sealed class MonthlyOutcome(
    int year,
    int month,
    int totalWeeks,
    int totalDays,
    int passedDays,
    double avgSleep,
    double avgWater,
    double avgMeals
)
{
    public int Year { get; } = year;
    public int Month { get; } = month;

    public int TotalWeeks { get; } = totalWeeks;
    public int TotalDays { get; } = totalDays;
    public int PassedDays { get; } = passedDays;

    public double ConsistencyRate { get; } = totalDays == 0 ? 0 : (double)passedDays / totalDays;

    public double AverageSleepHours { get; } = avgSleep;
    public double AverageWaterLiters { get; } = avgWater;
    public double AverageMealsCount { get; } = avgMeals;
}
