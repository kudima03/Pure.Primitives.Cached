using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Abstractions.Time;
using Pure.Primitives.Cached.Number;

namespace Pure.Primitives.Cached.Time;

public sealed record CachedTime : ITime
{
    public CachedTime(ITime value) :
        this(new CachedNumber<ushort>(value.Hour),
            new CachedNumber<ushort>(value.Minute),
            new CachedNumber<ushort>(value.Second),
            new CachedNumber<ushort>(value.Millisecond),
            new CachedNumber<ushort>(value.Microsecond),
            new CachedNumber<ushort>(value.Nanosecond))
    { }

    private CachedTime(INumber<ushort> hour,
        INumber<ushort> minute,
        INumber<ushort> second,
        INumber<ushort> millisecond,
        INumber<ushort> microsecond,
        INumber<ushort> nanosecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
        Microsecond = microsecond;
        Nanosecond = nanosecond;
    }

    public INumber<ushort> Hour { get; }

    public INumber<ushort> Minute { get; }

    public INumber<ushort> Second { get; }

    public INumber<ushort> Millisecond { get; }

    public INumber<ushort> Microsecond { get; }

    public INumber<ushort> Nanosecond { get; }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}