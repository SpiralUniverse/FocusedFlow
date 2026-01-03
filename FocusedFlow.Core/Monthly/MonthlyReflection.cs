namespace FocusedFlow.Core.Monthly;

public sealed class MonthlyReflection(
    string? whatWorked,
    string? whatDidNotWork,
    string? keyInsights
)
{
    public string? WhatWorked { get; set; } = whatWorked;
    public string? WhatDidNotWork { get; set; } = whatDidNotWork;
    public string? KeyInsights { get; set; } = keyInsights;
}
