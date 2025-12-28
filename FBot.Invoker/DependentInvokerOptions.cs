using System.Collections.ObjectModel;

namespace FBot.Invoker;

public sealed class DependentInvokerOptions
{
    public IReadOnlyDictionary<Type, ReadOnlyCollection<Type>> DependentConverters { get; init; } =
        new Dictionary<Type, ReadOnlyCollection<Type>>().AsReadOnly();

    public bool ThrowIfNoService { get; set; } = false;
}
