using FocusedFlow.Core.Monthly;

namespace FocusedFlow.Persistence.Abstractions;

public interface IMonthlyRecordRepository
{
    IReadOnlyList<MonthlyRecord> LoadAll();
    MonthlyRecord? Load(int year, int month);
    void Save(MonthlyRecord record);
    void Delete(int year, int month);
}
