using Pure.Primitives.Abstractions.DayOfWeek;
using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Cached.Tests.Fakes;

public sealed record DayOfWeekWithEvaluationCounter : IDayOfWeek
{
    private readonly IDayOfWeek _value;

    public DayOfWeekWithEvaluationCounter(IDayOfWeek value)
    {
        _value = value;
    }

    public int AccessCounter { get; private set; }

    INumber<ushort> IDayOfWeek.DayNumberValue
    {
        get
        {
            AccessCounter++;
            return _value.DayNumberValue;
        }
    }
}
