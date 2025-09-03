using Pure.Primitives.Abstractions.Date;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Cached.Number;

namespace Pure.Primitives.Cached.Date;

public sealed record CachedDate : IDate
{
    public CachedDate(IDate value)
        : this(
            new CachedNumber<ushort>(value.Day),
            new CachedNumber<ushort>(value.Month),
            new CachedNumber<ushort>(value.Year)
        )
    { }

    private CachedDate(INumber<ushort> day, INumber<ushort> month, INumber<ushort> year)
    {
        Day = day;
        Month = month;
        Year = year;
    }

    public INumber<ushort> Day { get; }

    public INumber<ushort> Month { get; }

    public INumber<ushort> Year { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
