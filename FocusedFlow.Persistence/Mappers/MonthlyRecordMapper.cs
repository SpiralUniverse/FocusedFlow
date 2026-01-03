using FocusedFlow.Core.Monthly;
using FocusedFlow.Persistence.Models;

namespace FocusedFlow.Persistence.Mappers;

public static class MonthlyRecordMapper
{
    // Save
    public static MonthlyRecordDto ToDto(MonthlyRecord record) =>
        new()
        {
            Year = record.Definition.Year,
            Month = record.Definition.Month,

            Weeks = record.Weeks.Select(w => w.WeekStart).ToList(),

            DirectionTheme = record.Direction?.Theme,
            DirectionPrimaryFocus = record.Direction?.PrimaryFocus,

            HabitToProtect = record.Habits?.HabitToProtect,
            HabitToWeaken = record.Habits?.HabitToWeaken,

            ReflectionWhatWorked = record.Reflection?.WhatWorked,
            ReflectionWhatDidNotWork = record.Reflection?.WhatDidNotWork,
            ReflectionKeyInsights = record.Reflection?.KeyInsights,

            Events = record
                .Events?.Select(e => new MonthlyEventDto
                {
                    Name = e.Name,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                })
                .ToList(),
        };

    // Load
    public static MonthlyRecord FromDto(MonthlyRecordDto dto)
    {
        var definition = new MonthDefinition(dto.Year, dto.Month);
        var record = new MonthlyRecord(definition);

        if (dto.DirectionTheme is not null || dto.DirectionPrimaryFocus is not null)
            record.SetDirection(dto.DirectionTheme, dto.DirectionPrimaryFocus);

        if (dto.HabitToProtect is not null || dto.HabitToWeaken is not null)
            record.SetHabits(dto.HabitToProtect, dto.HabitToWeaken);

        if (
            dto.ReflectionWhatWorked is not null
            || dto.ReflectionWhatDidNotWork is not null
            || dto.ReflectionKeyInsights is not null
        )
        {
            record.SetReflection(
                dto.ReflectionWhatWorked,
                dto.ReflectionWhatDidNotWork,
                dto.ReflectionKeyInsights
            );
        }

        if (dto.Events is not null)
        {
            var events = dto.Events.Select(e => new MonthlyEvent(e.Name, e.StartDate, e.EndDate));

            foreach (var e in events)
                record.AddEvent(e);
        }

        return record;
    }
}
