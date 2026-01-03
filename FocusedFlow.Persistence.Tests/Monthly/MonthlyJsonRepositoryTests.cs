using FocusedFlow.Core.Monthly;
using FocusedFlow.Persistence.Json;
using Xunit;

namespace FocusedFlow.Persistence.Tests.Monthly;

public sealed class MonthlyJsonRepositoryTests
{
    private static string CreateTempFilePath()
    {
        var dir = Path.Combine(Path.GetTempPath(), "FocusedFlowTests");
        Directory.CreateDirectory(dir);
        return Path.Combine(dir, $"monthly-{Guid.NewGuid()}.json");
    }

    private static MonthlyRecord CreateSampleMonthlyRecord(int year, int month)
    {
        var record = new MonthlyRecord(new MonthDefinition(year, month));

        record.SetDirection("Consistency", "Degree progress");
        record.SetHabits("Daily study", "Late nights");

        record.SetReflection(
            whatWorked: "Waking up early",
            whatDidNotWork: "Scrolling at night",
            keyInsights: "Sleep affects focus more than expected"
        );

        record.AddEvents(
            new[]
            {
                new MonthlyEvent(
                    "Midterm Exams",
                    new DateOnly(year, month, 10),
                    new DateOnly(year, month, 15)
                ),
                new MonthlyEvent(
                    "Basketball Tournament",
                    new DateOnly(year, month, 20),
                    new DateOnly(year, month, 20)
                ),
            }
        );

        return record;
    }

    [Fact]
    public void Save_Then_Load_Should_Return_Equivalent_Record()
    {
        // Arrange
        var path = CreateTempFilePath();
        var repo = new JsonMonthlyRecordRepository(path);
        var original = CreateSampleMonthlyRecord(2025, 1);

        // Act
        repo.Save(original);
        var loaded = repo.Load(2025, 1);

        // Assert
        Assert.NotNull(loaded);
        Assert.Equal(2025, loaded!.Definition.Year);
        Assert.Equal(1, loaded.Definition.Month);

        Assert.Equal("Consistency", loaded.Direction!.Theme);
        Assert.Equal("Degree progress", loaded.Direction.PrimaryFocus);

        Assert.Equal("Daily study", loaded.Habits!.HabitToProtect);
        Assert.Equal("Late nights", loaded.Habits.HabitToWeaken);

        Assert.Equal("Waking up early", loaded.Reflection!.WhatWorked);
        Assert.Equal("Scrolling at night", loaded.Reflection.WhatDidNotWork);
        Assert.Equal("Sleep affects focus more than expected", loaded.Reflection.KeyInsights);

        Assert.Equal(2, loaded.Events.Count);
        Assert.Contains(loaded.Events, e => e.Name == "Midterm Exams");
        Assert.Contains(loaded.Events, e => e.Name == "Basketball Tournament");
    }

    [Fact]
    public void Save_Same_Month_Should_Replace_Record()
    {
        // Arrange
        var path = CreateTempFilePath();
        var repo = new JsonMonthlyRecordRepository(path);

        var first = CreateSampleMonthlyRecord(2025, 2);
        repo.Save(first);

        var updated = new MonthlyRecord(new MonthDefinition(2025, 2));
        updated.SetDirection("Recovery", "Health");

        // Act
        repo.Save(updated);
        var loaded = repo.Load(2025, 2);

        // Assert
        Assert.NotNull(loaded);
        Assert.Equal("Recovery", loaded!.Direction!.Theme);
        Assert.Equal("Health", loaded.Direction.PrimaryFocus);
    }

    [Fact]
    public void LoadAll_Should_Return_Multiple_Months()
    {
        // Arrange
        var path = CreateTempFilePath();
        var repo = new JsonMonthlyRecordRepository(path);

        repo.Save(CreateSampleMonthlyRecord(2025, 3));
        repo.Save(CreateSampleMonthlyRecord(2025, 4));

        // Act
        var all = repo.LoadAll();

        // Assert
        Assert.Equal(2, all.Count);
        Assert.Contains(all, m => m.Definition.Month == 3);
        Assert.Contains(all, m => m.Definition.Month == 4);
    }

    [Fact]
    public void Delete_Should_Remove_Month()
    {
        // Arrange
        var path = CreateTempFilePath();
        var repo = new JsonMonthlyRecordRepository(path);

        repo.Save(CreateSampleMonthlyRecord(2025, 5));

        // Act
        repo.Delete(2025, 5);
        var loaded = repo.Load(2025, 5);

        // Assert
        Assert.Null(loaded);
    }

    [Fact]
    public void Invalid_Event_Data_Should_Throw()
    {
        // Arrange
        var path = CreateTempFilePath();
        var repo = new JsonMonthlyRecordRepository(path);

        var record = new MonthlyRecord(new MonthDefinition(2025, 6));

        // End date before start date (invalid)
        Assert.Throws<ArgumentException>(() =>
            record.AddEvents(
                new[]
                {
                    new MonthlyEvent(
                        "Broken Event",
                        new DateOnly(2025, 6, 10),
                        new DateOnly(2025, 6, 5)
                    ),
                }
            )
        );
    }
}
