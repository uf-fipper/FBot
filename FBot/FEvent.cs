using FBot.Invoker;

namespace FBot;

public interface IEvent { }

public interface IEvent<out T> : IEvent { }

public abstract class FEvent : IEvent { }

public abstract class FEvent<T> : FEvent, IEvent<T>
{
    public abstract T Data { get; }
}

public class FEventDependent : IFDependent
{
    public IDependentResult Invoke(FContext context, DependentInvokeInfo? info)
    {
        return DependentResult.Valid(context.Event);
    }
}
