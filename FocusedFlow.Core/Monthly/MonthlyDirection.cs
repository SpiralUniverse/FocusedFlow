namespace FocusedFlow.Core.Monthly;

public sealed class MonthlyDirection(string? theme, string? primaryFocus)
{
    public string? Theme { get; } = theme;
    public string? PrimaryFocus { get; } = primaryFocus;
}
