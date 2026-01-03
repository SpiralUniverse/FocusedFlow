namespace FocusedFlow.Core.Time;

public sealed class MonthlySnapshot
{
    public YearMonth Month { get; init; }

    public string NorhtStar { get; init; } = string.Empty;
    public string SuccessDefinition { get; init; } = string.Empty;
    public string HabitToProtect { get; init; } = string.Empty;
    public string HabitToWeaken { get; init; } = string.Empty;
    public string Notes { get; init; } = string.Empty;
}