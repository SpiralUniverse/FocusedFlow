using FocusedFlow.Core.Weekly;
using FocusedFlow.Persistence.Json;

namespace FocusedFlow.Persistence.Tests.Weekly;

public sealed class WeeklyJsonRepositoryTest
{
    private static string CreateTempFilePath()
    {
        return Path.Combine(Path.GetTempPath(), $"weekly_test_{Guid.NewGuid()}.json");
    }

    [Fact]
    public void SaveAndLoad_PreservesWeeklyMetadata()
    {
        // ---------- Arrange ----------
        var filePath = CreateTempFilePath();
        var repo = new JsonWeeklyRecordRepository(filePath);

        var weekStart = new DateOnly(2026, 1, 5);
        var definition = WeekDefinition.Custom(7);
        var record = new WeeklyRecord(weekStart, definition);

        record.SetFocus(
            weeklyIntent: "Stabilize routines",
            highPriorityFocus: "Basketball consistency",
            midPriorityFocus: "Blender practice"
        );

        record.SetReflection(
            struggledWith: "Late nights",
            recoveryFactors: "Morning runs",
            proudMoment: "Finished all study sessions"
        );

        // ---------- Act ----------
        repo.Save(record);
        var loaded = repo.Load(weekStart);

        // ---------- Assert ----------
        Assert.NotNull(loaded);

        Assert.Equal(weekStart, loaded!.WeekStart);
        Assert.Equal(7, loaded.Definition.LengthInDays);

        Assert.NotNull(loaded.Focus);
        Assert.Equal("Stabilize routines", loaded.Focus!.WeeklyIntent);
        Assert.Equal("Basketball consistency", loaded.Focus.HighPriorityFocus);

        Assert.NotNull(loaded.Reflection);
        Assert.Equal("Late nights", loaded.Reflection!.StruggledWith);
        Assert.Equal("Morning runs", loaded.Reflection.RecoveryFactors);
    }

    [Fact]
    public void LoadAll_ReturnsEmpty_WhenFileDoesNotExist()
    {
        // ---------- Arrange ----------
        var filePath = CreateTempFilePath();
        var repo = new JsonWeeklyRecordRepository(filePath);

        // ---------- Act ----------
        var records = repo.LoadAll();

        // ---------- Assert ----------
        Assert.Empty(records);
    }

    [Fact]
    public void Delete_RemovesWeeklyRecord()
    {
        // ---------- Arrange ----------
        var filePath = CreateTempFilePath();
        var repo = new JsonWeeklyRecordRepository(filePath);

        var weekStart = new DateOnly(2026, 1, 12);
        var record = new WeeklyRecord(weekStart, WeekDefinition.Custom(5));

        repo.Save(record);

        // ---------- Act ----------
        repo.Delete(weekStart);
        var loaded = repo.Load(weekStart);

        // ---------- Assert ----------
        Assert.Null(loaded);
    }
}
