using System.Reflection;
using FBot.Invoker;

namespace FBot;

public class FDependentMethod : DependentMethod
{
    public IFRule Rule { get; }

    public FDependentMethod(
        MethodInfo methodInfo,
        Func<IDependentContext, DependentInvokeInfo?, object?> getTarget,
        IFRule rule
    )
        : base(methodInfo, getTarget)
    {
        Rule = rule;
    }

    public FDependentMethod(DependentMethod dependentMethod, IFRule rule)
        : base(dependentMethod)
    {
        Rule = rule;
    }

    public FDependentMethod(FDependentMethod fDependentMethod)
        : base(fDependentMethod)
    {
        Rule = fDependentMethod.Rule;
    }
}
