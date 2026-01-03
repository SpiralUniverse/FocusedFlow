namespace FocusedFlow.Persistence.Models;

public sealed class DailyRecordDto
{
    public DateOnly Date { get; set; }
    public Dictionary<string, int>? Presence { get; set; }

    public double SleepHours { get; set; }
    public double WaterLiters { get; set; }
    public int MealsCount { get; set; }

    public bool AnchorCompleted { get; set; }

    public string? WhatMattered { get; set; }
    public string? WhatDrained { get; set; }

    public int? MeditationMinutes { get; set; }
    public string? EnjoymentNotes { get; set; }
}
