namespace FocusedFlow.Persistence.Models;

public sealed class DailyOutcomeDto
{
    public DateOnly Date { get; set; }
    public bool IsPassed { get; set; }
}
