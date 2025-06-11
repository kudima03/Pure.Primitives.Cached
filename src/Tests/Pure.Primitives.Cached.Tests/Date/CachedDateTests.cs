using Pure.Primitives.Abstractions.Date;
using Pure.Primitives.Cached.Date;
using Pure.Primitives.Cached.Tests.Fakes;
using Pure.Primitives.Date;

namespace Pure.Primitives.Cached.Tests.Date;

using Date = Primitives.Date.Date;

public sealed record CachedDateTests
{
    [Fact]
    public void UnderlyingValueEvaluatesOnce()
    {
        NumberWithEvaluationCounter<ushort> underlyingYear = new NumberWithEvaluationCounter<ushort>(2000);
        NumberWithEvaluationCounter<ushort> underlyingMonth = new NumberWithEvaluationCounter<ushort>(1);
        NumberWithEvaluationCounter<ushort> underlyingDay = new NumberWithEvaluationCounter<ushort>(1);
        IDate cached = new CachedDate(new Date(underlyingYear, underlyingMonth, underlyingDay));

        foreach (int i in Enumerable.Range(0, 100))
        {
            _ = cached.Year.NumberValue;
            _ = cached.Month.NumberValue;
            _ = cached.Day.NumberValue;
        }

        Assert.True(new[]
        {
            underlyingYear,
            underlyingMonth,
            underlyingDay
        }.All(x => x.AccessCounter == 1));
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new CachedDate(new CurrentDate()).GetHashCode());
    }
    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new CachedDate(new CurrentDate()).ToString());
    }
}