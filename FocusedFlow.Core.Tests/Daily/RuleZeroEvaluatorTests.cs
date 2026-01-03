using FocusedFlow.Core.Daily;


namespace FocusedFlow.Core.Tests.Daily;

public class RuleZeroEvaluatorTests
{
    [Fact]
    public void DayIsNotPassed_WhenAnchoreNotCompleted()
    {
        //Arrange
        var record = new DailyRecord(new DateOnly(2026, 1, 1));
        var evaluator = new RuleZeroEvaluator();


        //Act
        bool passed = evaluator.IsDayPassed(record);

        //Assert
        Assert.False(passed);

    }

    [Fact]
    public void DayIsPassed_WhenAnchorCompleted()
    {
        //Arrange
        var record = new DailyRecord(new DateOnly(2026, 1, 1));
        var evaluator = new RuleZeroEvaluator();

        //Act
        record.CompleteAnchor();
        bool passed = evaluator.IsDayPassed(record);


        //Assert
        Assert.True(passed);
        
    }
}