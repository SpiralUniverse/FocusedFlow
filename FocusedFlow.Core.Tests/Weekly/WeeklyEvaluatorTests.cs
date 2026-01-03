using FocusedFlow.Core.Daily;
using FocusedFlow.Core.Weekly;

namespace FocusedFlow.Core.Tests.Weekly;

public class WeeklyEvaluatorTests
{
    [Fact]
    public void WeeklyConsistency_IsCalculatedCorrectly()
    {

        var start = DateOnly.FromDateTime(DateTime.Today);
        var week = new WeeklyRecord(start, WeekDefinition.FullWeek());
        var evaluator = new WeeklyEvaluator();

        var day1 = new DailyRecord(start);
        day1.UpdateBaseline(8, 2, 3);
        day1.CompleteAnchor();

        var day2 = new DailyRecord(start.AddDays(1));
        day2.UpdateBaseline(6, 1.5, 2);

        week.AddDay(new DailyEvaluator().Evaluate(day1));
        week.AddDay(new DailyEvaluator().Evaluate(day2));

        var outcome = evaluator.Evaluate(week);

        Assert.Equal(2, outcome.TotalDays);
        Assert.Equal(1, outcome.PassedDays);
        Assert.Equal(0.5, outcome.ConsistencyRate);
        Assert.Equal(7, outcome.AverageSleepHours);
    }
}
