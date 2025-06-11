using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Cached.String;
using Pure.Primitives.Cached.Tests.Fakes;
using Pure.Primitives.String;
using System.Collections;

namespace Pure.Primitives.Cached.Tests.String;

public sealed record CachedStringTests
{
    [Fact]
    public void EnumeratesAsTyped()
    {
        const string expected = "expected value";
        StringWithEvaluationCounter underlyingValue = new StringWithEvaluationCounter(expected);
        IEnumerable<IChar> cached = new CachedString(underlyingValue);

        char[] chars = cached.Select(x => x.CharValue).ToArray();

        Assert.Equal(expected, new string(chars));
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        const string expected = "expected value";
        StringWithEvaluationCounter underlyingValue = new StringWithEvaluationCounter(expected);
        IEnumerable cached = new CachedString(underlyingValue);

        char[] chars = (from IChar i in cached select i.CharValue).ToArray();

        Assert.Equal(expected, new string(chars));
    }

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