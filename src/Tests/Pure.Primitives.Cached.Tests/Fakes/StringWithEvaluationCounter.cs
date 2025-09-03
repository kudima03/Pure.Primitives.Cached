using System.Collections;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.Cached.Tests.Fakes;

using Char = Primitives.Char.Char;

public sealed record StringWithEvaluationCounter : IString
{
    private readonly string _value;

    public StringWithEvaluationCounter(string value)
    {
        _value = value;
    }

    public int AccessCounter { get; private set; }

    string IString.TextValue
    {
        get
        {
            AccessCounter++;
            return _value;
        }
    }

    public IEnumerator<IChar> GetEnumerator()
    {
        return _value.Select(x => new Char(x)).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
