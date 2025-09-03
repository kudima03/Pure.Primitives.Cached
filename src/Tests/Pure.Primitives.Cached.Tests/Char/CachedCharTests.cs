using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Cached.Char;
using Pure.Primitives.Cached.Tests.Fakes;

namespace Pure.Primitives.Cached.Tests.Char;

using Char = Primitives.Char.Char;

public sealed record CachedCharTests
{
    [Fact]
    public void UnderlyingValueEvaluatesOnce()
    {
        CharWithEvaluationCounter underlyingValue = new CharWithEvaluationCounter('A');
        IChar cached = new CachedChar(underlyingValue);
        foreach (int i in Enumerable.Range(0, 100))
        {
            _ = cached.CharValue;
        }

        Assert.Equal(1, underlyingValue.AccessCounter);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new CachedChar(new Char('A')).GetHashCode());
    }
    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new CachedChar(new Char('A')).ToString());
    }
}