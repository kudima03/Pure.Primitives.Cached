using Pure.Primitives.Abstractions.Time;
using Pure.Primitives.Cached.Tests.Fakes;
using Pure.Primitives.Cached.Time;
using Pure.Primitives.Time;

namespace Pure.Primitives.Cached.Tests.Time;

public sealed record CachedTimeTests
{
    [Fact]
    public void UnderlyingValueEvaluatesOnce()
    {
        NumberWithEvaluationCounter<ushort> underlyingHour =
            new NumberWithEvaluationCounter<ushort>(1);
        NumberWithEvaluationCounter<ushort> underlyingMinute =
            new NumberWithEvaluationCounter<ushort>(2);
        NumberWithEvaluationCounter<ushort> underlyingSecond =
            new NumberWithEvaluationCounter<ushort>(3);
        NumberWithEvaluationCounter<ushort> underlyingMillisecond =
            new NumberWithEvaluationCounter<ushort>(4);
        NumberWithEvaluationCounter<ushort> underlyingMicrosecond =
            new NumberWithEvaluationCounter<ushort>(5);
        NumberWithEvaluationCounter<ushort> underlyingNanosecond =
            new NumberWithEvaluationCounter<ushort>(6);
        ITime cached = new CachedTime(
            new Time(
                underlyingHour,
                underlyingMinute,
                underlyingSecond,
                underlyingMillisecond,
                underlyingMicrosecond,
                underlyingNanosecond
            )
        );

        foreach (int i in Enumerable.Range(0, 100))
        {
            _ = cached.Hour.NumberValue;
            _ = cached.Minute.NumberValue;
            _ = cached.Second.NumberValue;
            _ = cached.Millisecond.NumberValue;
            _ = cached.Microsecond.NumberValue;
            _ = cached.Nanosecond.NumberValue;
        }

        Assert.True(
            new[]
            {
                underlyingHour,
                underlyingMinute,
                underlyingSecond,
                underlyingMillisecond,
                underlyingMicrosecond,
                underlyingNanosecond,
            }.All(x => x.AccessCounter == 1)
        );
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() =>
            new CachedTime(new CurrentTime()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() =>
            new CachedTime(new CurrentTime()).ToString()
        );
    }
}
