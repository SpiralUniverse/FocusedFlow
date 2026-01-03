namespace FocusedFlow.Core.Daily;

public sealed class RuleZeroEvaluator
{
    public bool IsDayPassed(DailyRecord record) { return record.IsAnchorCompleted; }
}