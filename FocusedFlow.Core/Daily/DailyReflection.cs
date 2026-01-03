namespace FocusedFlow.Core.Daily;

public sealed class DailyReflection(string? whatMattered, string? whatDrained)
{
    public string? WhatMattered { get; } = whatMattered;
    public string? WhatDrained { get; } = whatDrained;
}
