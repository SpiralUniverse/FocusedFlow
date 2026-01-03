namespace FocusedFlow.Core.Daily;

public sealed class DailyOutcome
{
    public DateOnly Date { get; }
    public bool Passed { get; }
    public double SleepHours { get; }
    public double WaterLiters { get; }
    public int MealsCount { get; }

    public DailyOutcome(DailyRecord record, bool passed)
    {
        Date = record.Date;
        Passed = passed;

        SleepHours = record.SleepHours;
        WaterLiters = record.WaterLiters;
        MealsCount = record.MealsCount;
    }
}