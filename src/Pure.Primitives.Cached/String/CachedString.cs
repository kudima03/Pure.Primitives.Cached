using System.Collections;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.Cached.String;

using Char = Primitives.Char.Char;

public sealed record CachedString : IString
{
    private readonly Lazy<string> _lazyValue;

    public CachedString(IString value)
        : this(
            new Lazy<string>(
                () => value.TextValue,
                LazyThreadSafetyMode.ExecutionAndPublication
            )
        )
    { }

    private CachedString(Lazy<string> lazyValue)
    {
        _lazyValue = lazyValue;
    }

    public string TextValue => _lazyValue.Value;

    public IEnumerator<IChar> GetEnumerator()
    {
        return _lazyValue.Value.Select(x => new Char(x)).GetEnumerator();
    }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
