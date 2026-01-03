namespace FocusedFlow.Core.Monthly;

public sealed class MonthlyEvent
{
    public string Name { get; }
    public DateOnly StartDate { get; }
    public DateOnly EndDate { get; }

    public MonthlyEvent(string name, DateOnly startDate, DateOnly endDate)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Event name cannot be empty.");
        if (endDate < startDate)
            throw new ArgumentException("End date cannot be before start date.");

        Name = name;
        StartDate = startDate;
        EndDate = endDate;
    }
}
