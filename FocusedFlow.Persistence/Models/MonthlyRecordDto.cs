using FocusedFlow.Core.Monthly;

namespace FocusedFlow.Persistence.Models;

public sealed class MonthlyRecordDto
{
    public int Year { get; set; }
    public int Month { get; set; }

    public List<DateOnly> Weeks { get; set; } = [];

    public MonthlyDirection? Direction { get; set; }

    public MonthlyHabits? Habits { get; set; }

    public MonthlyReflection? Reflection { get; set; }
    public List<MonthlyEvent>? Events { get; set; }
}
