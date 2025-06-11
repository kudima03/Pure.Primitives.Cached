using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Cached.Guid;
using Pure.Primitives.Cached.Tests.Fakes;

namespace Pure.Primitives.Cached.Tests.Guid;

using Guid = Primitives.Guid.Guid;

public sealed record CachedGuidTests
{
    [Fact]
    public void UnderlyingValueEvaluatesOnce()
    {
        GuidWithEvaluationCounter underlyingValue = new GuidWithEvaluationCounter(new System.Guid());
        IGuid cached = new CachedGuid(underlyingValue);
        foreach (int i in Enumerable.Range(0, 100))
        {
            _ = cached.GuidValue;
        }

        Assert.Equal(1, underlyingValue.AccessCounter);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new CachedGuid(new Guid()).GetHashCode());
    }
    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new CachedGuid(new Guid()).ToString());
    }
}