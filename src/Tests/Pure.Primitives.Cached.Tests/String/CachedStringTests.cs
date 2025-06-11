using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Cached.String;
using Pure.Primitives.Cached.Tests.Fakes;
using Pure.Primitives.String;

namespace Pure.Primitives.Cached.Tests.String;

public sealed record CachedStringTests
{
    [Fact]
    public void UnderlyingValueEvaluatesOnce()
    {
        StringWithEvaluationCounter underlyingValue = new StringWithEvaluationCounter(string.Empty);
        IString cached = new CachedString(underlyingValue);
        foreach (int i in Enumerable.Range(0, 100))
        {
            _ = cached.TextValue;
        }

        Assert.Equal(1, underlyingValue.AccessCounter);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new CachedString(new EmptyString()).GetHashCode());
    }
    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new CachedString(new EmptyString()).ToString());
    }
}