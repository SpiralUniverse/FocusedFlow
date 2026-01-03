namespace FocusedFlow.Persistence.Models;

public sealed class WeeklyRecordDto
{
    public DateOnly WeekStart { get; set; }
    public int WeekLength { get; set; }

    public List<DateOnly> Days { get; set; } = [];

    // Reflection
    public string? StruggledWith { get; set; }
    public string? RecoveryFactors { get; set; }
    public string? ProudMoment { get; set; }

    // Focus
    public string? WeeklyIntent { get; set; }
    public string? HighPriorityFocus { get; set; }
    public string? MidPriorityFocus { get; set; }
}
