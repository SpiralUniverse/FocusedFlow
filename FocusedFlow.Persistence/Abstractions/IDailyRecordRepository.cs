using FocusedFlow.Core.Daily;

namespace FocusedFlow.Persistence.Abstraction;

public interface IDailyRecordRepository
{
    IReadOnlyList<DailyRecord> LoadAll();
    DailyRecord? Load(DateOnly date);
    void Save(DailyRecord record);
    void Delete(DateOnly date);
}
