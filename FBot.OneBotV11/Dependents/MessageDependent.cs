using DependentInvoker;
using FBot;
using FBot.OneBotV11.Events.Messages;
using FBot.OneBotV11.Events.Messages.Segments;

namespace FBot.OneBotV11.Dependents;

public class MessageDependent : IFDependent
{
    public IDependentResult Invoke(FContext context, DependentInvokeInfo? info)
    {
        if (context.Event is BaseMessageEvent messageEvent)
        {
            return DependentResult.Valid(messageEvent.GetMessage());
        }
        return DependentResult.Invalid();
    }
}
