using Pure.Primitives.Abstractions.Char;

namespace Pure.Primitives.Cached.Char;

public sealed record CachedChar : IChar
{
    private readonly Lazy<char> _lazyValue;

    public CachedChar(IChar value)
        : this(
            new Lazy<char>(
                () => value.CharValue,
                LazyThreadSafetyMode.ExecutionAndPublication
            )
        )
    { }

    private CachedChar(Lazy<char> lazyValue)
    {
        _lazyValue = lazyValue;
    }

    public char CharValue => _lazyValue.Value;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
