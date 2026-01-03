namespace FocusedFlow.Persistence.Models;

public sealed class MonthlyRecordDto
{
    public int Year { get; set; }
    public int Month { get; set; }

    public List<DateOnly> Weeks { get; set; } = [];

    public string? DirectionTheme { get; set; }
    public string? DirectionPrimaryFocus { get; set; }

    public string? HabitToProtect { get; set; }
    public string? HabitToWeaken { get; set; }

    public string? ReflectionWhatWorked { get; set; }
    public string? ReflectionWhatDidNotWork { get; set; }
    public string? ReflectionKeyInsights { get; set; }

    public List<MonthlyEventDto>? Events { get; set; }
}
