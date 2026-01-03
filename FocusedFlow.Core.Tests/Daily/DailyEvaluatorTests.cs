using FocusedFlow.Core.Daily;

namespace FocusedFlow.Core.Tests.Daily;

public class DailyEvaluatorTest
{
    [Fact]
    public void Evaluate_ReturnsOutcomeWithCorrectPassState()
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Today);
        var record = new DailyRecord(date);
        var evaluator = new DailyEvaluator();

        record.UpdateBaseline(8, 2, 3);
        record.CompleteAnchor();

        // Act
        var outcome = evaluator.Evaluate(record);

        // Assert
        Assert.True(outcome.Passed);
        Assert.Equal(8, outcome.SleepHours);
        Assert.Equal(2, outcome.WaterLiters);
        Assert.Equal(3, outcome.MealsCount);
    }
}