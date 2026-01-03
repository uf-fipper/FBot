using FBot.Invoker;
using Microsoft.Extensions.DependencyInjection;

namespace FBot;

public interface IFRule
{
    Task<bool> IsMatchAsync(FContext context);
}

public interface IFRuleAny : IFRule
{
    DependentMethod Dependency { get; }

    async Task<bool> IFRule.IsMatchAsync(FContext context)
    {
        var invoker = context.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = await invoker.InvokeAsync(Dependency, context);
        var value = result.Value;
        if (value is not bool boolValue)
        {
            return false;
        }
        return result.IsValid && boolValue;
    }
}

public class FRule : IFRuleAny
{
    public FRule(DependentMethod dependency)
    {
        Dependency = dependency;
        if (Dependency.ReturnType != typeof(bool))
        {
            throw new ArgumentException("Dependency must return a boolean value.");
        }
    }

    public FRule(Delegate del)
        : this(new DependentMethod(del)) { }

    public static FRule EmptyRule { get; } = new FRule(() => true);

    public DependentMethod Dependency { get; }

    public static FAndRule And(params IFRule[] rules)
    {
        return new FAndRule(rules);
    }

    public static FOrRule Or(params IFRule[] rules)
    {
        return new FOrRule(rules);
    }
}

public class FAndRule(params IFRule[] rules) : IFRule
{
    public async Task<bool> IsMatchAsync(FContext context)
    {
        FRule rule1 = new(() => true);
        FRule rule2 = new(() => true);
        var r = rule1 & rule2;
        foreach (var rule in rules)
        {
            if (!await rule.IsMatchAsync(context))
            {
                return false;
            }
        }
        return true;
    }
}

public class FOrRule(params IFRule[] rules) : IFRule
{
    public async Task<bool> IsMatchAsync(FContext context)
    {
        foreach (var rule in rules)
        {
            if (await rule.IsMatchAsync(context))
            {
                return true;
            }
        }
        return false;
    }
}

public static class FRuleExtensions
{
#if NET10_0_OR_GREATER
    extension(IFRule)
    {
        public static FAndRule operator &(IFRule rule1, IFRule rule2)
        {
            return new FAndRule([rule1, rule2]);
        }

        public static FOrRule operator |(IFRule rule1, IFRule rule2)
        {
            return new FOrRule([rule1, rule2]);
        }
    }
#endif
}
