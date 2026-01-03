namespace FBot.Invoker;

public interface IDependentContext
{
    Dictionary<Type, object?> CachedDependents { get; }

    IServiceProvider ServiceProvider { get; }

    IDictionary<object, object?> Items { get; }
}

public class DependentContext : IDependentContext
{
    public Dictionary<Type, object?> CachedDependents { get; } = [];

    public required IServiceProvider ServiceProvider { get; init; }

    public IDictionary<object, object?> Items { get; } = new Dictionary<object, object?>();
}
