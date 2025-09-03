using Pure.Primitives.Abstractions.Date;
using Pure.Primitives.Abstractions.DateTime;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Abstractions.Time;
using Pure.Primitives.Cached.Date;
using Pure.Primitives.Cached.Time;

namespace Pure.Primitives.Cached.DateTime;

public sealed record CachedDateTime : IDateTime
{
    private readonly IDate _cachedDate;

    private readonly ITime _cachedTime;

    public CachedDateTime(IDateTime value)
        : this(new CachedDate(value), new CachedTime(value)) { }

    private CachedDateTime(IDate cachedDate, ITime cachedTime)
    {
        _cachedDate = cachedDate;
        _cachedTime = cachedTime;
    }

    public INumber<ushort> Year => _cachedDate.Year;

    public INumber<ushort> Month => _cachedDate.Month;

    public INumber<ushort> Day => _cachedDate.Day;

    public INumber<ushort> Hour => _cachedTime.Hour;

    public INumber<ushort> Minute => _cachedTime.Minute;

    public INumber<ushort> Second => _cachedTime.Second;

    public INumber<ushort> Millisecond => _cachedTime.Millisecond;

    public INumber<ushort> Microsecond => _cachedTime.Microsecond;

    public INumber<ushort> Nanosecond => _cachedTime.Nanosecond;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
