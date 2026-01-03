namespace FBot.Invoker.Tests.Models;

public class SubStateDependent : IDependentAny
{
    public Delegate Dependency => Invoke;

    public bool UseCache => false;

    private DependentResult Invoke(
        SubDependentContext subDependentContext,
        DependentInvokeInfo info
    )
    {
        if (info.ParameterInfo.ParameterType == typeof(int))
        {
            return DependentResult.Valid(subDependentContext.IntValue);
        }

        if (info.ParameterInfo.ParameterType == typeof(string))
        {
            return DependentResult.Valid(subDependentContext.StringValue);
        }

        return DependentResult.Invalid();
    }
}

public class FromSubStateAttribute() : FromDependentAttribute(typeof(SubStateDependent)) { }
