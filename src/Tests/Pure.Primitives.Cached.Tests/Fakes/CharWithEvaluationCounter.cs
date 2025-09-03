using Pure.Primitives.Abstractions.Char;

namespace Pure.Primitives.Cached.Tests.Fakes;

public sealed record CharWithEvaluationCounter : IChar
{
    private readonly char _value;

    public CharWithEvaluationCounter(char value)
    {
        _value = value;
    }

    public int AccessCounter { get; private set; }

    char IChar.CharValue
    {
        get
        {
            AccessCounter++;
            return _value;
        }
    }
}
