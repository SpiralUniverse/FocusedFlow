namespace FocusedFlow.Core.Weekly;

public sealed class WeekDefinition
{
    public int LengthInDays { get; }

    private WeekDefinition(int lengthInDays)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(lengthInDays);
        LengthInDays = lengthInDays;
    }

    public static WeekDefinition FullWeek() => new(7);

    public static WeekDefinition Custom(int days) => new(days);
}
