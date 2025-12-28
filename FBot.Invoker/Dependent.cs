using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace FBot.Invoker;

public class DependentInvokeInfo(ParameterInfo parameterInfo, object?[] args)
{
    public ParameterInfo ParameterInfo => parameterInfo;

    public object?[] Args => args;
}

public interface IDependent
{
    IDependentResult Invoke(IDependentContext context, DependentInvokeInfo? info);
}

public interface IDependentAny : IDependent
{
    Delegate Dependency { get; }

    IDependentResult IDependent.Invoke(IDependentContext context, DependentInvokeInfo? info)
    {
        var invoker = context.ServiceProvider.GetRequiredService<IDependentInvoker>();
        return invoker.Invoke(Dependency, context, info);
    }
}
