using FocusedFlow.Core.Baseline;
using FocusedFlow.Core.Dimensions;
using FocusedFlow.Core.Priorities;
using FocusedFlow.Core.Singals;

namespace FocusedFlow.Core.Time;

public sealed class DailySnapshot
{
    public DateOnly Date { get; init; }
    public DailyBaseLine DailyBaseLine { get; init; } = new();
    public AnchorActivity Anchor { get; init; } = new();
    public Dictionary<LifeDimension, EngagementSignal> Presence { get; init; } = CreateDefaultPresence();

    public string Reflection { get; init; } = string.Empty;

    public RuleZeroState RuleZero { get; init; } = RuleZeroState.Unknown;

    private static Dictionary<LifeDimension, EngagementSignal> CreateDefaultPresence()
    {
        return Enum.GetValues<LifeDimension>().ToDictionary(dim => dim, dim => EngagementSignal.Absent);
    }
}

public enum RuleZeroState
{
    Unknown,
    Failed,
    Succeeded
}