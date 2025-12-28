using FBot.Invoker;

namespace FBot;

public class FResponse
{
    public object? Value { get; private set; }

    public bool HasResponse { get; private set; }

    public void SetResponse(object? value)
    {
        Value = value;
        HasResponse = true;
    }

    public void ClearResponse()
    {
        Value = null;
        HasResponse = false;
    }
}

public class FContext(IBot bot, IEvent @event, FResponse response) : DependentContext
{
    public IBot Bot => bot;

    public IEvent Event => @event;

    public FResponse Response => response;
}
