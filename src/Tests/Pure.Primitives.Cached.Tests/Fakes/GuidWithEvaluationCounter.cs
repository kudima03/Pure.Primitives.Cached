using Pure.Primitives.Abstractions.Guid;

namespace Pure.Primitives.Cached.Tests.Fakes;

public sealed record GuidWithEvaluationCounter : IGuid
{
    private readonly System.Guid _value;

    public GuidWithEvaluationCounter(System.Guid value)
    {
        _value = value;
    }

    public int AccessCounter { get; private set; }

    System.Guid IGuid.GuidValue
    {
        get
        {
            AccessCounter++;
            return _value;
        }
    }
}
