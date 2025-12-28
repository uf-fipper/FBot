namespace FBot.Invoker;

public interface IDependentResult
{
    bool IsValid { get; }

    object? Value { get; }
}

public class DependentResult(bool isValid, object? value) : IDependentResult
{
    public bool IsValid => isValid;

    public object? Value => value;

    public static DependentResult Valid(object? value) => new(true, value);

    public static DependentResult Invalid() => new(false, null);
}
