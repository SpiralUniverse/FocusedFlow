namespace FocusedFlow.Core.Daily;

public sealed class DailySignals(int meditationMinutes, string? enjoymentNotes)
{
    public int MeditationalMinuts { get; } = meditationMinutes;
    public string? EnjoymentNotes { get; } = enjoymentNotes;
}
