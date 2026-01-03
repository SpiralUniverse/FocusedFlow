using FocusedFlow.Core.Daily;
using FocusedFlow.Core.Dimensions;
using FocusedFlow.Persistence.Json;

namespace FocusedFlow.Persistence.Tests.Daily;

public sealed class DailyJsonRepositoryTests
{
    private static string CreateTempFilePath() =>
        Path.Combine(Path.GetTempPath(), $"daily_test_{Guid.NewGuid()}.json");

    [Fact]
    public void SaveAndLoad_PreservesAllDailyData()
    {
        var filePath = CreateTempFilePath();
        var repo = new JsonDailyRecordRepository(filePath);

        var date = new DateOnly(2026, 1, 1);
        var record = new DailyRecord(date);

        record.UpdateBaseline(7.5, 2.0, 3);
        record.CompleteAnchor();

        record.SetPresence(LifeDimension.Body, PresenceLevel.Meaningful);
        record.SetPresence(LifeDimension.Mind, PresenceLevel.Touched);

        record.SetReflection(
            whatMattered: "Focused study session",
            whatDrained: "Too much screen time"
        );

        record.SetSignals(meditaitonMinutes: 15, enjoymentNotes: "BasketBall with freinds");

        repo.Save(record);
        var loaded = repo.Load(date);

        Assert.NotNull(loaded);

        Assert.Equal(7.5, loaded.SleepHours);
        Assert.Equal(2.0, loaded.WaterLiters);
        Assert.Equal(3, loaded.MealsCount);

        Assert.True(loaded.IsAnchorCompleted);
        Assert.Equal(2, loaded.Presence.Count);
        Assert.Contains(
            loaded.Presence,
            P => P.Dimension == LifeDimension.Body && P.Level == PresenceLevel.Meaningful
        );
        Assert.NotNull(loaded.Refelection);
        Assert.Equal("Focused study session", loaded.Refelection.WhatMattered);

        Assert.NotNull(loaded.Signals);
        Assert.Equal(15, loaded.Signals.MeditationalMinuts);
    }

    [Fact]
    public void Delete_RemovesDailyRecord()
    {
        var filepath = CreateTempFilePath();
        var repo = new JsonDailyRecordRepository(filepath);

        var date = new DateOnly(2026, 1, 2);
        var record = new DailyRecord(date);

        record.UpdateBaseline(6, 1.5, 2);
        repo.Save(record);
        repo.Delete(date);
        var loaded = repo.Load(date);

        Assert.Null(loaded);
    }

    [Fact]
    public void LoadAll_ReturnEmpty_WhenFileDoesNotExist()
    {
        var filePath = CreateTempFilePath();
        var repo = new JsonDailyRecordRepository(filePath);
        var records = repo.LoadAll();
        Assert.Empty(records);
    }
}
