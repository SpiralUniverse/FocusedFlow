using FocusedFlow.Core.Monthly;
using FocusedFlow.Core.Weekly;

namespace FocusedFlow.Core.Tests.Monthly;

public class MonthlyEvaluatorTests
{
    [Fact]
    public void MonthlyOutcome_ComputesCorrectAggregates()
    {
        var def = new MonthDefinition(2026, 1);
        var record = new MonthlyRecord(def);
        var evaluator = new MonthlyEvaluator();

        var week1 = new WeeklyOutcome(
            def.StartDate,
            def.StartDate.AddDays(6),
            totalDays: 7,
            passedDays: 5,
            avgSleep: 7,
            avgWater: 2,
            avgMeals: 3
        );

        var week2 = new WeeklyOutcome(
            def.StartDate.AddDays(7),
            def.StartDate.AddDays(13),
            totalDays: 7,
            passedDays: 4,
            avgSleep: 6,
            avgWater: 1.8,
            avgMeals: 2.5
        );

        record.AddWeek(week1);
        record.AddWeek(week2);

        var outcome = evaluator.Evaluate(record);

        Assert.Equal(2, outcome.TotalWeeks);
        Assert.Equal(14, outcome.TotalDays);
        Assert.Equal(9, outcome.PassedDays);
        Assert.Equal(9.0 / 14.0, outcome.ConsistencyRate);
    }
}
