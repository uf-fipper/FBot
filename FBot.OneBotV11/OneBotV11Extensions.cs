using FBot.Invoker;
using FBot.OneBotV11.Dependents;
using FBot.OneBotV11.Events.Messages.Segments;

namespace FBot.OneBotV11;

public static partial class OneBotV11Extensions
{
    public static IFDriverBuilder AddOneBotV11(
        this IServiceCollection services,
        OneBotV11Config oneBotV11Config
    )
    {
        return AddOneBotV11(
            services,
            cfg =>
            {
                cfg.Bots = oneBotV11Config.Bots;
            }
        );
    }

    public static IFDriverBuilder AddOneBotV11(
        this IServiceCollection services,
        Action<OneBotV11Config> configureOptions
    )
    {
        services.Configure(configureOptions);
        return services.AddOneBotV11Internal();
    }

    public static IFDriverBuilder AddOneBotV11(
        this IServiceCollection services,
        IConfigurationSection section
    )
    {
        services.Configure<OneBotV11Config>(section);
        return services.AddOneBotV11Internal();
    }

    private static IFDriverBuilder AddOneBotV11Internal(this IServiceCollection services)
    {
        var fBotBuilder = services.AddFBot();
        fBotBuilder.InvokerBuilder.AddDependentConverter<Message, MessageDependent>();
        services.AddSingleton<OneBotV11Adapter>();
        services.AddScoped<MessageDependent>();
        return fBotBuilder;
    }

    public static IEndpointRouteBuilder UseOneBotV11(
        this IEndpointRouteBuilder endpoints,
        CancellationToken cancellationToken = default
    )
    {
        var adapter = endpoints.ServiceProvider.GetRequiredService<OneBotV11Adapter>();
        adapter.Init(endpoints, cancellationToken);
        return endpoints;
    }
}
