namespace FocusedFlow.Core.Daily;

public sealed class DailyEvaluator
{
    private readonly RuleZeroEvaluator ruleZero = new();
    public DailyOutcome Evaluate(DailyRecord record)
    {
        bool passed = ruleZero.IsDayPassed(record);
        return new DailyOutcome(record, passed);
    }
}