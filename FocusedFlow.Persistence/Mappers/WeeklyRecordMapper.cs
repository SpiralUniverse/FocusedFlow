using FocusedFlow.Core.Weekly;
using FocusedFlow.Persistence.Models;

namespace FocusedFlow.Persistence.Mappers;

public static class WeeklyRecordMapper
{
    public static WeeklyRecordDto ToDto(WeeklyRecord record) =>
        new WeeklyRecordDto
        {
            WeekStart = record.WeekStart,
            WeekLength = record.Definition.LengthInDays,

            Days = record.Days.Select(d => d.Date).ToList(),

            StruggledWith = record.Reflection?.StruggledWith,
            RecoveryFactors = record.Reflection?.RecoveryFactors,
            ProudMoment = record.Reflection?.ProudMoment,

            WeeklyIntent = record.Focus?.WeeklyIntent,
            HighPriorityFocus = record.Focus?.HighPriorityFocus,
            MidPriorityFocus = record.Focus?.MidPriorityFocus,
        };

    public static WeeklyRecord FromDto(WeeklyRecordDto dto)
    {
        var definition = WeekDefinition.Custom(dto.WeekLength);
        var record = new WeeklyRecord(dto.WeekStart, definition);

        if (
            dto.StruggledWith is not null
            || dto.RecoveryFactors is not null
            || dto.ProudMoment is not null
        )
        {
            record.SetReflection(dto.StruggledWith, dto.RecoveryFactors, dto.ProudMoment);
        }

        if (
            dto.WeeklyIntent is not null
            || dto.HighPriorityFocus is not null
            || dto.MidPriorityFocus is not null
        )
        {
            record.SetFocus(dto.WeeklyIntent, dto.HighPriorityFocus, dto.MidPriorityFocus);
        }

        return record;
    }
}
