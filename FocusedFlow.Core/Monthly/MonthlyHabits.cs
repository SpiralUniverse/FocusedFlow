namespace FocusedFlow.Core.Monthly;

public sealed class MonthlyHabits(string? habitToProtect, string? habitToWeaken)
{
    public string? HabitToProtect { get; set; } = habitToProtect;
    public string? HabitToWeaken { get; set; } = habitToWeaken;
}
