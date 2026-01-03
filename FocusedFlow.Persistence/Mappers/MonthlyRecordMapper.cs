using FocusedFlow.Core.Monthly;
using FocusedFlow.Persistence.Models;

namespace FocusedFlow.Persistence.Mappers;

public static class MonthlyRecordMapper
{
    //Save
    public static MonthlyRecordDto ToDto(MonthlyRecord record) =>
        new()
        {
            Year = record.Definition.Year,
            Month = record.Definition.Month,

            Weeks = record.Weeks.Select(w => w.WeekStart).ToList(),

            Direction = record.Direction,
            Habits = record.Habits,
            Reflection = record.Reflection,
            Events = record.Events?.ToList(),
        };
}
