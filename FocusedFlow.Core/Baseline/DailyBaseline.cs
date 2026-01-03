namespace FocusedFlow.Core.Baseline;

///<summary>
/// Represents the physiological baseline of a day.
/// This provides context, not scoring.
/// </summary>

public sealed class DailyBaseLine
{
    public double SleepHours {get; init; }

    public double WaterLiters {get; init; }
    
    public int MealsCount { get; init; }
}