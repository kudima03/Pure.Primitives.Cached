using Pure.Primitives.Abstractions.DateTime;
using Pure.Primitives.Cached.DateTime;
using Pure.Primitives.Cached.Tests.Fakes;
using Pure.Primitives.DateTime;

namespace Pure.Primitives.Cached.Tests.DateTime;

using Date = Primitives.Date.Date;
using DateTime = Primitives.DateTime.DateTime;
using Time = Primitives.Time.Time;

public sealed record CachedDateTimeTests
{
    [Fact]
    public void UnderlyingValueIsCached()
    {
        NumberWithEvaluationCounter<ushort> underlyingYear =
            new NumberWithEvaluationCounter<ushort>(2000);
        NumberWithEvaluationCounter<ushort> underlyingMonth =
            new NumberWithEvaluationCounter<ushort>(1);
        NumberWithEvaluationCounter<ushort> underlyingDay =
            new NumberWithEvaluationCounter<ushort>(17);
        NumberWithEvaluationCounter<ushort> underlyingHour =
            new NumberWithEvaluationCounter<ushort>(12);
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

        IDateTime cached = new CachedDateTime(
            new DateTime(
                new Date(underlyingDay, underlyingMonth, underlyingYear),
                new Time(
                    underlyingHour,
                    underlyingMinute,
                    underlyingSecond,
                    underlyingMillisecond,
                    underlyingMicrosecond,
                    underlyingNanosecond
                )
            )
        );

        foreach (int i in Enumerable.Range(0, 100))
        {
            _ = cached.Year.NumberValue;
            _ = cached.Month.NumberValue;
            _ = cached.Day.NumberValue;
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
                underlyingYear,
                underlyingMonth,
                underlyingDay,
                underlyingHour,
                underlyingMinute,
                underlyingSecond,
                underlyingMillisecond,
                underlyingMicrosecond,
                underlyingNanosecond,
            }.All(x => x.AccessCounter == 2)
        );
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new CachedDateTime(new CurrentDateTime()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new CachedDateTime(new CurrentDateTime()).ToString()
        );
    }
}
