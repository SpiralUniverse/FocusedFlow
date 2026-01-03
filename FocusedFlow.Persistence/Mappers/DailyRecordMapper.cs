using FocusedFlow.Core.Daily;
using FocusedFlow.Core.Dimensions;
using FocusedFlow.Persistence.Models;

namespace FocusedFlow.Persistence.Mappers;

public static class DailyRecordMapper
{
    //Save
    public static DailyRecordDto ToDto(DailyRecord record) =>
        new()
        {
            //Baseline
            Date = record.Date,
            SleepHours = record.SleepHours,
            WaterLiters = record.WaterLiters,
            MealsCount = record.MealsCount,
            AnchorCompleted = record.IsAnchorCompleted,

            //Presence
            Presence = record.Presence.Any()
                ? record.Presence.ToDictionary(p => p.Dimension.ToString(), p => (int)p.Level)
                : null,

            //Refelection
            WhatMattered = record.Refelection?.WhatMattered,
            WhatDrained = record.Refelection?.WhatDrained,

            //Signals
            MeditationMinutes = record.Signals?.MeditationalMinuts,
            EnjoymentNotes = record.Signals?.EnjoymentNotes,
        };

    //Load
    public static DailyRecord FromDto(DailyRecordDto dto)
    {
        var record = new DailyRecord(dto.Date);

        //baseline
        record.UpdateBaseline(dto.SleepHours, dto.WaterLiters, dto.MealsCount);

        if (dto.AnchorCompleted)
            record.CompleteAnchor();

        //Presence
        if (dto.Presence is not null)
            foreach (var entry in dto.Presence)
            {
                var dimension = Enum.Parse<LifeDimension>(entry.Key);
                var level = (PresenceLevel)entry.Value;

                record.SetPresence(dimension, level);
            }

        //Reflection
        if (dto.WhatMattered is not null || dto.WhatDrained is not null)
            record.SetReflection(dto.WhatMattered, dto.WhatDrained);

        //Signals
        if (dto.MeditationMinutes.HasValue || dto.EnjoymentNotes is not null)
            record.SetSignals(dto.MeditationMinutes ?? 0, dto.EnjoymentNotes);

        return record;
    }
}
