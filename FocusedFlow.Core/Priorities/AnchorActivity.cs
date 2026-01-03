using FocusedFlow.Core.Dimensions;

namespace FocusedFlow.Core.Priorities;

public sealed class AnchorActivity
{
    public string Name {get;init;} = string.Empty;

    public LifeDimension Dimension {get;init;}

    public ActivityNature Nature {get; init;}

    public ActivityStatus Status {get; init;} = ActivityStatus.Missed;

}