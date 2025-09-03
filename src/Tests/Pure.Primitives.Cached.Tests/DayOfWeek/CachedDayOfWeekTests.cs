using Pure.Primitives.Abstractions.DayOfWeek;
using Pure.Primitives.Cached.DayOfWeek;
using Pure.Primitives.Cached.Tests.Fakes;
using Pure.Primitives.DayOfWeek;

namespace Pure.Primitives.Cached.Tests.DayOfWeek;

public sealed record CachedDayOfWeekTests
{
    [Fact]
    public void UnderlyingValueEvaluatesOnce()
    {
        DayOfWeekWithEvaluationCounter underlyingValue =
            new DayOfWeekWithEvaluationCounter(new Monday());
        IDayOfWeek cached = new CachedDayOfWeek(underlyingValue);
        foreach (int i in Enumerable.Range(0, 100))
        {
            _ = cached.DayNumberValue.NumberValue;
        }

        Assert.Equal(1, underlyingValue.AccessCounter);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() =>
            new CachedDayOfWeek(new Monday()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() =>
            new CachedDayOfWeek(new Monday()).ToString()
        );
    }
}
