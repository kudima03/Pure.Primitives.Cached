using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.Cached.Tests.Fakes;

public sealed record BoolWithEvaluationCounter : IBool
{
    private readonly bool _value;

    public BoolWithEvaluationCounter(bool value)
    {
        _value = value;
    }

    public int AccessCounter { get; private set; }

    bool IBool.BoolValue
    {
        get
        {
            AccessCounter++;
            return _value;
        }
    }
}