using FocusedFlow.Core.Dimensions;

namespace FocusedFlow.Core.Daily;

public sealed class DailyRecord(DateOnly date)
{
    private readonly List<DailyPresence> _presence = [];
    public IReadOnlyCollection<DailyPresence> Presence => _presence.AsReadOnly();
    public DailyReflection? Refelection { get; private set; }
    public DailySignals? Signals { get; private set; }

    public DateOnly Date { get; } = date;
    public double SleepHours { get; private set; }
    public double WaterLiters { get; private set; }

    public int MealsCount { get; private set; }

    public bool IsAnchorCompleted { get; private set; }

    public void SetPresence(LifeDimension dimension, PresenceLevel level)
    {
        _presence.RemoveAll(p => p.Dimension == dimension);
        _presence.Add(new DailyPresence(dimension, level));
    }

    public void UpdateBaseline(double sleepHours, double waterLiters, int mealsCount)
    {
        SleepHours = sleepHours;
        WaterLiters = waterLiters;
        MealsCount = mealsCount;
    }

    public void CompleteAnchor() => IsAnchorCompleted = true;

    public void ResetAnchor() => IsAnchorCompleted = false;

    public void SetReflection(string? whatMattered, string? whatDrained) =>
        Refelection = new(whatMattered, whatDrained);

    public void SetSignals(int meditaitonMinutes, string? enjoymentNotes) =>
        Signals = new DailySignals(meditaitonMinutes, enjoymentNotes);
}
