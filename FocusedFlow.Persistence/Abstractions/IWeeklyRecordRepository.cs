using FocusedFlow.Core.Weekly;

namespace FocusedFlow.Persistence.Abstractions;

public interface IWeeklyRecordRepository
{
    IReadOnlyList<WeeklyRecord> LoadAll();
    WeeklyRecord? Load(DateOnly weekStart);
    void Save(WeeklyRecord record);
    void Delete(DateOnly weekStart);
}
