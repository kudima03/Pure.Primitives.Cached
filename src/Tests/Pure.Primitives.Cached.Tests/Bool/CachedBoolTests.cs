using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Bool;
using Pure.Primitives.Cached.Bool;
using Pure.Primitives.Cached.Tests.Fakes;

namespace Pure.Primitives.Cached.Tests.Bool;

public sealed record CachedBoolTests
{
    [Fact]
    public void UnderlyingValueEvaluatesOnce()
    {
        BoolWithEvaluationCounter underlyingValue = new BoolWithEvaluationCounter(true);
        IBool cached = new CachedBool(underlyingValue);
        foreach (int i in Enumerable.Range(0, 100))
        {
            _ = cached.BoolValue;
        }

        Assert.Equal(1, underlyingValue.AccessCounter);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() =>
            new CachedBool(new False()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() =>
            new CachedBool(new False()).ToString()
        );
    }
}
