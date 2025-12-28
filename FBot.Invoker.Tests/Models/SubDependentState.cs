namespace FBot.Invoker.Tests.Models;

public class SubDependentContext(string stringValue, int intValue) : DependentContext
{
    public string StringValue { get; set; } = stringValue;

    public int IntValue { get; set; } = intValue;
}
