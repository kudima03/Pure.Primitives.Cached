using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Cached.Tests.Fakes;

public sealed record NumberWithEvaluationCounter<T> : INumber<T> where T : System.Numerics.INumber<T>
{
    private readonly T _value;

    public NumberWithEvaluationCounter(T value)
    {
        _value = value;
    }

    public int AccessCounter { get; private set; }

    T INumber<T>.NumberValue
    {
        get
        {
            AccessCounter++;
            return _value;
        }
    }
}