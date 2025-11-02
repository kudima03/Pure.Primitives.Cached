using Pure.Primitives.Abstractions.DayOfWeek;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Cached.Number;

namespace Pure.Primitives.Cached.DayOfWeek;

public sealed record CachedDayOfWeek : IDayOfWeek
{
    private readonly Lazy<INumber<ushort>> _lazyValue;

    public CachedDayOfWeek(IDayOfWeek value)
        : this(
            new Lazy<INumber<ushort>>(
                () => new CachedNumber<ushort>(value.DayNumberValue),
                LazyThreadSafetyMode.ExecutionAndPublication
            )
        )
    { }

    private CachedDayOfWeek(Lazy<INumber<ushort>> lazyValue)
    {
        _lazyValue = lazyValue;
    }

    public INumber<ushort> DayNumberValue => _lazyValue.Value;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
