using FocusedFlow.Core.Weekly;

namespace FocusedFlow.Core.Monthly;

public sealed class MonthlyEvaluator
{
    public MonthlyOutcome Evaluate(MonthlyRecord record)
    {
        int totalWeeks = record.Weeks.Count;

        int totalDays = record.Weeks.Sum(w => w.TotalDays);
        int passedDays = record.Weeks.Sum(w => w.PassedDays);

        double avgSleep = totalWeeks == 0 ? 0 : record.Weeks.Average(w => w.AverageSleepHours);
        double avgWater = totalWeeks == 0 ? 0 : record.Weeks.Average(w => w.AverageWaterLiters);
        double avgMeals = totalWeeks == 0 ? 0 : record.Weeks.Average(w => w.AverageMealsCount);

        return new MonthlyOutcome(
            record.Definition.Year,
            record.Definition.Month,
            totalWeeks,
            totalDays,
            passedDays,
            avgSleep,
            avgWater,
            avgMeals
        );
    }
}
