using FBot.Invoker;

namespace FBot;

public interface IBot { }

public class FBotDependent : IFDependent
{
    public IDependentResult Invoke(FContext context, DependentInvokeInfo? info)
    {
        return DependentResult.Valid(context.Bot);
    }
}
