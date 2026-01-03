namespace FocusedFlow.Core.Weekly;

public sealed class WeeklyEvaluator
{
    public WeeklyOutcome Evaluate(WeeklyRecord record)
    {
        int totalDays = record.Days.Count;
        int passedDays = record.Days.Count(d => d.Passed);
        
        double avgSleep = totalDays == 0 ? 0 : record.Days.Average(d => d.SleepHours);
        double avgWater = totalDays == 0 ? 0 : record.Days.Average(d => d.WaterLiters);
        double avgMeals = totalDays == 0 ? 0 : record.Days.Average(d => d.MealsCount);

        return new WeeklyOutcome(
            weekStart: record.WeekStart,
            weekEnd: record.WeekEnd,
            totalDays,
            passedDays,
            avgSleep,
            avgWater,
            avgMeals
        );
    }
}