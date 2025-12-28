namespace FBot.Invoker;

[AttributeUsage(AttributeTargets.Parameter)]
public class FromDependentAttribute : Attribute
{
    public FromDependentAttribute(Type dependentType)
        : this(dependentType, []) { }

    public FromDependentAttribute(Type dependentType, object?[] args)
    {
        if (!dependentType.IsAssignableTo(typeof(IDependent)))
        {
            throw new NotSupportedException();
        }

        DependentType = dependentType;
        Args = args;
    }

    public Type DependentType { get; }

    public object?[] Args { get; }

    public bool UseCache { get; set; } = true;
}
