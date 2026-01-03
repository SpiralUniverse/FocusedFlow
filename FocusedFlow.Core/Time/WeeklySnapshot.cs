using FocusedFlow.Core.Dimensions;
using FocusedFlow.Core.Priorities;

namespace FocusedFlow.Core.Time;

public sealed class WeeklySnapshot
{
    public DateOnly StartDate { get; init; }
    public DateOnly EndDate { get; init; }
    public MidPriorityFocus Focus { get; init; } = new();

    public Dictionary<LifeDimension, RadarScore> Radar { get; init; } = CreateDefaultRadar();

    public string StruggledWith { get; init; } = string.Empty;

    public string RecoveredBy { get; init; } = string.Empty;

    public string Summary { get; init; } = string.Empty;

    private static Dictionary<LifeDimension, RadarScore> CreateDefaultRadar()
    {
        return Enum.GetValues<LifeDimension>().ToDictionary(dim=>dim, dim=>new RadarScore(1));
    }
}