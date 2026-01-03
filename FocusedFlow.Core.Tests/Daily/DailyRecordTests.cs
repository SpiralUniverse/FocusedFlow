using FocusedFlow.Core.Daily;

namespace FocusedFlow.Core.Tests.Daily;


public class DailyRecordTests
{
    [Fact]
    public void UpdateBaseline_UpdateValuesCorrectly()
    {
        //Arange
        var record = new DailyRecord(new DateOnly(2026, 1, 1));

        //Act
        record.UpdateBaseline
        (sleepHours: 7.5,
        waterLiters: 2.0,
        mealsCount: 3
        );

        //Asser
        Assert.Equal(7.5, record.SleepHours);
        Assert.Equal(2.0, record.WaterLiters);
        Assert.Equal(3, record.MealsCount);
        
    }
}