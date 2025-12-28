using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace FBot.Invoker;

public class ContextDependent : IDependent
{
    public IDependentResult Invoke(IDependentContext context, DependentInvokeInfo? info)
    {
        return DependentResult.Valid(context);
    }
}

public class ParameterInfoDependent : IDependent
{
    public IDependentResult Invoke(IDependentContext context, DependentInvokeInfo? info)
    {
        return DependentResult.Valid(info?.ParameterInfo);
    }
}

public class ParameterInfoDependentAttribute()
    : FromDependentAttribute(typeof(ParameterInfoDependent));

public class FromKeyedServiceDependent(IServiceProvider serviceProvider) : IDependentAny
{
    public Delegate Dependency => Invoke;

    public IDependentResult Invoke(
        [ArgDependent(0)] object key,
        [ParameterInfoDependent] ParameterInfo parameterInfo
    )
    {
        var obj = serviceProvider.GetKeyedService(parameterInfo.ParameterType, key);
        return DependentResult.Valid(obj);
    }
}

public class ArgDependent : IDependent
{
    public IDependentResult Invoke(IDependentContext context, DependentInvokeInfo? info)
    {
        if (info == null || info.Args.Length != 1)
        {
            return DependentResult.Invalid();
        }

        var index = info.Args[0];
        if (index is int i && i >= 0 && i < info.Args.Length)
        {
            return DependentResult.Valid(info.Args[i]);
        }
        return DependentResult.Invalid();
    }
}

public class ArgDependentAttribute(int index)
    : FromDependentAttribute(typeof(ArgDependent), [index]) { }

public class ArgsDependent : IDependent
{
    public IDependentResult Invoke(IDependentContext context, DependentInvokeInfo? info)
    {
        if (info == null || info.Args.Length != 1)
        {
            return DependentResult.Invalid();
        }

        var index = info.Args[0];
        if (index is int i && i >= 0 && i < info.Args.Length)
        {
            return DependentResult.Valid(info.Args[i]);
        }
        return DependentResult.Invalid();
    }
}

public class FromServiceDependent(IServiceProvider serviceProvider) : IDependentAny
{
    public Delegate Dependency => Invoke;

    public IDependentResult Invoke(
        IDependentContext context,
        DependentInvokeInfo info,
        DependentInvokerOptions options
    )
    {
        object? obj;
        if (options.ThrowIfNoService)
        {
            // not support
            obj = serviceProvider.GetRequiredService(info.ParameterInfo.ParameterType);
        }
        else
        {
            obj = serviceProvider.GetService(info.ParameterInfo.ParameterType);
        }
        return DependentResult.Valid(obj);
    }
}

public class ItemsDependent : IDependent
{
    public IDependentResult Invoke(IDependentContext context, DependentInvokeInfo? info)
    {
        return DependentResult.Valid(context.Items);
    }
}

public class ContextItemsAttribute() : FromDependentAttribute(typeof(ContextItemsAttribute));
