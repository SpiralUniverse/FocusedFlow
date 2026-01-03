namespace FocusedFlow.Core.Monthly;

public sealed class MonthDefinition
{
    public int Year { get; }
    public int Month { get; }

    public MonthDefinition(int year, int month)
    {
        if (month < 1 || month > 12)
            throw new ArgumentOutOfRangeException(nameof(month));

        Year = year;
        Month = month;
    }

    public DateOnly StartDate => new(Year, Month, 1);

    public DateOnly EndDate => new(Year, Month, DateTime.DaysInMonth(Year, Month));
}
