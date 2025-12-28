using FBot.Invoker;

namespace FBot;

public interface IFDependent : IDependent
{
    IDependentResult IDependent.Invoke(IDependentContext context, DependentInvokeInfo? info)
    {
        if (context is FContext fContext)
        {
            return Invoke(fContext, info);
        }
        return DependentResult.Invalid();
    }

    IDependentResult Invoke(FContext context, DependentInvokeInfo? info);
}
