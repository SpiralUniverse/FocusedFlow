using System.Net.Http.Headers;
using FocusedFlow.Core.Daily;

namespace FocusedFlow.Core.Weekly;

public sealed class WeeklyRecord(DateOnly weekStart, WeekDefinition definition)
{
    private readonly List<DailyOutcome> _days = [];
    public DateOnly WeekStart { get; } = weekStart;
    public WeeklyReflection? Reflection { get; private set; }
    public WeeklyFocus? Focus { get; private set; }
    public DateOnly WeekEnd { get; } = weekStart.AddDays(definition.LengthInDays - 1);
    public WeekDefinition Definition { get; } = definition;
    public IReadOnlyList<DailyOutcome> Days => _days;

    public void AddDay(DailyOutcome outcome)
    {
        if (outcome.Date < WeekStart || outcome.Date > WeekEnd)
            throw new InvalidOperationException("Day is outside the week range.");
        if (_days.Any(d => d.Date == outcome.Date))
            throw new InvalidOperationException("Duplicate day.");
        if (_days.Count >= Definition.LengthInDays)
            throw new InvalidOperationException("Week is already full.");

        _days.Add(outcome);
    }

    public void SetFocus(
        string? weeklyIntent,
        string? highPriorityFocus,
        string? midPriorityFocus
    ) => Focus = new WeeklyFocus(weeklyIntent, highPriorityFocus, midPriorityFocus);

    public void SetReflection(
        string? struggledWith,
        string? recoveryFactors,
        string? proudMoment
    ) => Reflection = new WeeklyReflection(struggledWith, recoveryFactors, proudMoment);
}
