using System.Reflection;

namespace FBot.Invoker;

public class DependentMethod
{
    public DependentMethod(
        MethodInfo methodInfo,
        Func<IDependentContext, DependentInvokeInfo?, object?> getTarget
    )
    {
        var isAsync = DependentHelper.CheckIsAsync(methodInfo, out var returnType);
        MethodInfo = methodInfo;
        GetTarget = getTarget;
        ReturnType = returnType;
        IsAsync = isAsync;
    }

    public DependentMethod(Delegate del)
        : this(del.Method, (_, _) => del.Target) { }

    public DependentMethod(DependentMethod method)
        : this(method.MethodInfo, method.GetTarget) { }

    public MethodInfo MethodInfo { get; }

    public Func<IDependentContext, DependentInvokeInfo?, object?> GetTarget { get; }

    public Type ReturnType { get; }

    public bool IsAsync { get; }

    public DependentMethodParameterInfo[] GetParameters(DependentInvokerOptions options)
    {
        return MethodInfo
            .GetParameters()
            .Select(x => new DependentMethodParameterInfo(this, x, options))
            .ToArray();
    }
}
