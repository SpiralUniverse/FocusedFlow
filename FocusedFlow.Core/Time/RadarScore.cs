using System.Net.NetworkInformation;

namespace FocusedFlow.Core.Time;

public readonly struct RadarScore
{
    public int Value {get;}

    public RadarScore(int value)
    {
        if(value <1 || value > 5)
            throw new ArgumentOutOfRangeException(nameof(value), "Radar score must be between 1 and 5.");
        
        Value = value;
    }

    public static implicit operator int (RadarScore rs) => rs.Value;
    public static implicit operator RadarScore(int value) => new (value);

    public override string ToString() => Value.ToString();
}