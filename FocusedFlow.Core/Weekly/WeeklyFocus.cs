namespace FocusedFlow.Core.Weekly;

public sealed class WeeklyFocus(
    string? weeklyIntent,
    string? highPriorityFocus,
    string? midPriorityFocus
)
{
    public string? WeeklyIntent { get; } = weeklyIntent;
    public string? HighPriorityFocus { get; set; } = highPriorityFocus;
    public string? MidPriorityFocus { get; set; } = midPriorityFocus;
}
