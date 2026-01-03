namespace FBot.Invoker.Tests.Models;

public class DictionaryDependent : IDependent
{
    public IDependentResult Invoke(IDependentContext context, DependentInvokeInfo? info)
    {
        return DependentResult.Valid(
            new Dictionary<string, object?>()
            {
                { "key1", "value1" },
                { "key2", "value2" },
                { "int1", 1 },
                { "int2", 2 },
                { "nullKey", null },
            }
        );
    }
}

public class FromDictionaryDependent : IDependentAny
{
    public Delegate Dependency => Invoke;

    public bool UseCache => false;

    public IDependentResult Invoke(
        DependentInvokeInfo? info,
        [FromDependent(typeof(DictionaryDependent))] Dictionary<string, object?> dict
    )
    {
        if (info?.Args.Length != 1)
        {
            return DependentResult.Invalid();
        }

        var key = (string?)info.Args[0] ?? info.ParameterInfo.Name;
        if (key is null)
        {
            return DependentResult.Invalid();
        }
        if (dict.TryGetValue(key, out var value))
        {
            return DependentResult.Valid(value);
        }
        return DependentResult.Invalid();
    }
}

public class FromDictionaryAttribute(string? key = null)
    : FromDependentAttribute(typeof(FromDictionaryDependent), [key]) { }

public class FromDictionaryWithCacheDependent : IDependentAny
{
    public Delegate Dependency => Invoke;

    public bool UseCache => true;

    public IDependentResult Invoke(
        DependentInvokeInfo? info,
        [FromDependent(typeof(DictionaryDependent))] Dictionary<string, object?> dict
    )
    {
        if (info?.Args.Length != 1)
        {
            return DependentResult.Invalid();
        }

        var key = (string?)info.Args[0] ?? info.ParameterInfo.Name;
        if (key is null)
        {
            return DependentResult.Invalid();
        }
        if (dict.TryGetValue(key, out var value))
        {
            return DependentResult.Valid(value);
        }
        return DependentResult.Invalid();
    }
}

public class FromDictionaryWithCacheAttribute(string? key = null)
    : FromDependentAttribute(typeof(FromDictionaryWithCacheDependent), [key]) { }
