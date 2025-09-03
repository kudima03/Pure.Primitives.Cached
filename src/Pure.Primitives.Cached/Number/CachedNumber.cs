namespace Pure.Primitives.Cached.Number;

public sealed record CachedNumber<T> : Abstractions.Number.INumber<T>
    where T : System.Numerics.INumber<T>
{
    private readonly Lazy<T> _lazyValue;

    public CachedNumber(Abstractions.Number.INumber<T> value)
        : this(
            new Lazy<T>(
                () => value.NumberValue,
                LazyThreadSafetyMode.ExecutionAndPublication
            )
        )
    { }

    private CachedNumber(Lazy<T> lazyValue)
    {
        _lazyValue = lazyValue;
    }

    T Abstractions.Number.INumber<T>.NumberValue => _lazyValue.Value;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
