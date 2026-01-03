namespace FocusedFlow.Core.Weekly;

public sealed class WeeklyReflection(
    string? struggledWith,
    string? recoveryFactors,
    string? proudMoment
)
{
    public string? StruggledWith { get; } = struggledWith;
    public string? RecoveryFactors { get; } = recoveryFactors;
    public string? ProudMoment { get; } = proudMoment;
}
