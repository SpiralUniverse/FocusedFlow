using FocusedFlow.Core.Weekly;

namespace FocusedFlow.Core.Monthly;

public sealed class MonthlyRecord(MonthDefinition definition)
{
    public MonthDefinition Definition { get; } = definition;

    private readonly List<WeeklyOutcome> _weeks = [];
    public IReadOnlyList<WeeklyOutcome> Weeks => _weeks;

    private readonly List<MonthlyEvent> _events = [];
    public IReadOnlyList<MonthlyEvent> Events => _events;

    public MonthlyDirection? Direction { get; private set; }
    public MonthlyHabits? Habits { get; private set; }
    public MonthlyReflection? Reflection { get; private set; }

    public void AddWeek(WeeklyOutcome week)
    {
        if (week.WeekStart < Definition.StartDate || week.WeekEnd > Definition.EndDate)
            throw new InvalidOperationException("Week outside month range.");

        if (_weeks.Any(w => w.WeekStart == week.WeekStart))
            throw new InvalidOperationException("Duplicate week.");

        _weeks.Add(week);
    }

    public void AddEvent(string name, DateOnly start, DateOnly end) =>
        _events.Add(new MonthlyEvent(name, start, end));

    public void AddEvent(MonthlyEvent e) =>
        _events.Add(new MonthlyEvent(e.Name, e.StartDate, e.EndDate));

    public void AddEvents(MonthlyEvent[] events)
    {
        foreach (MonthlyEvent e in events)
            _events.Add(e);
    }

    public void SetDirection(string? theme, string? primaryFocus) =>
        Direction = new MonthlyDirection(theme, primaryFocus);

    public void SetHabits(string? habitToProtect, string? habitToWeaken) =>
        Habits = new MonthlyHabits(habitToProtect, habitToWeaken);

    public void SetReflection(string? whatWorked, string? whatDidNotWork, string? keyInsights) =>
        Reflection = new MonthlyReflection(whatWorked, whatDidNotWork, keyInsights);
}
