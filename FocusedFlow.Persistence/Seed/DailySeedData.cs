using FocusedFlow.Core.Daily;

namespace FocusedFlow.Persistence.Seed;

public static class DailySeedData
{
    public static List<DailyRecord> CreateSampleWeek(DateOnly start)
    {
        var days = new List<DailyRecord>();
        for (int i = 0; i < 5; i++)
        {
            var record = new DailyRecord(start.AddDays(i));
            record.UpdateBaseline(7 + i % 2, 2, 3);
            if (i % 2 == 0)
                record.CompleteAnchor();
            days.Add(record);
        }

        return days;
    }
}
