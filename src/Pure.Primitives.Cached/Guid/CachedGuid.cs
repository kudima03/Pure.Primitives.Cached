using Pure.Primitives.Abstractions.Guid;

namespace Pure.Primitives.Cached.Guid;

public sealed record CachedGuid : IGuid
{
    private readonly Lazy<System.Guid> _lazyValue;

    public CachedGuid(IGuid value) :
        this(new Lazy<System.Guid>(() => value.GuidValue, LazyThreadSafetyMode.ExecutionAndPublication))
    { }

    private CachedGuid(Lazy<System.Guid> lazyValue)
    {
        _lazyValue = lazyValue;
    }

    System.Guid IGuid.GuidValue => _lazyValue.Value;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}