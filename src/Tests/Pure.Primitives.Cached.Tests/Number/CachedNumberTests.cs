using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Cached.Number;
using Pure.Primitives.Cached.Tests.Fakes;
using Pure.Primitives.Number;

namespace Pure.Primitives.Cached.Tests.Number;

public sealed record CachedNumberTests
{
    [Fact]
    public void UnderlyingValueEvaluatesOnce()
    {
        NumberWithEvaluationCounter<int> underlyingValue = new NumberWithEvaluationCounter<int>(10);
        INumber<int> cached = new CachedNumber<int>(underlyingValue);
        foreach (int i in Enumerable.Range(0, 100))
        {
            _ = cached.NumberValue;
        }

        Assert.Equal(1, underlyingValue.AccessCounter);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new CachedNumber<int>(new MinInt()).GetHashCode());
    }
    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new CachedNumber<int>(new MinInt()).ToString());
    }
}