using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FBot.Invoker;

public interface IDependentInvokerBuilder
{
    DependentConverterMap DependentConverterMap { get; }

    bool ThrowIfNoService { get; set; }
}

public class DependentInvokerBuilder(IServiceCollection services) : IDependentInvokerBuilder
{
    public IServiceCollection Services => services;

    public DependentConverterMap DependentConverterMap { get; } = [];

    public bool ThrowIfNoService { get; set; }
}

public static class DependentInvokerBuilderExtensions
{
    public static IDependentInvokerBuilder AddDependentInvoker(this IServiceCollection services)
    {
        var builder =
            GetServiceFromCollection<IDependentInvokerBuilder>(services)
            ?? new DependentInvokerBuilder(services);
        services.TryAddSingleton<IDependentInvokerBuilder>(builder);
        services.TryAddSingleton<DependentInvokerOptions>(provider =>
        {
            var builder = provider.GetRequiredService<IDependentInvokerBuilder>();
            var dependentConverterMap = builder.DependentConverterMap;
            var dependentConverter = dependentConverterMap
                .ToDictionary(item => item.Key, item => item.Value.ToList().AsReadOnly())
                .AsReadOnly();
            var options = new DependentInvokerOptions()
            {
                DependentConverters = dependentConverter,
                ThrowIfNoService = builder.ThrowIfNoService,
            };
            return options;
        });
        services.TryAddSingleton<ContextDependent>();
        services.TryAddSingleton<ArgDependent>();
        services.TryAddSingleton<ParameterInfoDependent>();
        services.TryAddSingleton<ItemsDependent>();
        // 因为serviceProvide要以scope的形式获取
        services.TryAddScoped<IDependentInvoker, DependentInvoker>();
        // 注册内置模块
        AddDefaultSubTypesDependent<IDependentContext, ContextDependent>(builder);
        return builder;
    }

    public static IDependentInvokerBuilder AddDependentConverter(
        this IDependentInvokerBuilder builder,
        Type type,
        Type dependentType
    )
    {
        builder.DependentConverterMap.Add(type, dependentType);
        return builder;
    }

    public static IDependentInvokerBuilder AddDependentConverter<T, TDependent>(
        this IDependentInvokerBuilder builder
    )
        where TDependent : IDependent
    {
        builder.DependentConverterMap.Add<T, TDependent>();
        return builder;
    }

    public static IDependentInvokerBuilder AddDefaultSubTypesDependent<TBase, TDependent>(
        this IDependentInvokerBuilder builder
    )
    {
        foreach (var typeInfo in ReflectionHelper.GetSubTypes<TBase>())
        {
            builder.AddDependentConverter(typeInfo, typeof(TDependent));
        }

        return builder;
    }

    public static IDependentInvokerBuilder AddDefaultSubTypesDependent(
        this IDependentInvokerBuilder builder,
        Type baseType,
        Type dependentType
    )
    {
        foreach (var typeInfo in ReflectionHelper.GetSubTypes(baseType))
        {
            builder.AddDependentConverter(typeInfo, dependentType);
        }

        return builder;
    }

    public static IDependentInvokerBuilder SetThrowIfNoService(
        this IDependentInvokerBuilder builder,
        bool value = false
    )
    {
        builder.ThrowIfNoService = value;
        return builder;
    }

    private static T? GetServiceFromCollection<T>(IServiceCollection services)
    {
        return (T?)services.LastOrDefault(d => d.ServiceType == typeof(T))?.ImplementationInstance;
    }
}
