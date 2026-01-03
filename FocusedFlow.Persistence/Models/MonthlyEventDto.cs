namespace FocusedFlow.Persistence.Models;

public sealed class MonthlyEventDto
{
    public string Name { get; set; } = string.Empty;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}
