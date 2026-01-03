using FocusedFlow.Core.Dimensions;

namespace FocusedFlow.Core.Daily;

public sealed class DailyPresence(LifeDimension dimension, PresenceLevel level)
{
    public LifeDimension Dimension { get; } = dimension;
    public PresenceLevel Level { get; } = level;
}
