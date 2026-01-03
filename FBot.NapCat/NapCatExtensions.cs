using FBot.OneBotV11;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FBot.NapCat;

public static class NapCatExtensions
{
    public static IFDriverBuilder AddNapCat(
        this IServiceCollection services,
        OneBotV11Config oneBotV11Config
    )
    {
        return AddNapCat(
            services,
            cfg =>
            {
                cfg.Bots = oneBotV11Config.Bots;
            }
        );
    }

    public static IFDriverBuilder AddNapCat(
        this IServiceCollection services,
        Action<OneBotV11Config> configureOptions
    )
    {
        var fBotBuilder = services.AddOneBotV11(configureOptions);
        services.AddNapCatInternal();
        return fBotBuilder;
    }

    public static IFDriverBuilder AddNapCat(
        this IServiceCollection services,
        IConfigurationSection section
    )
    {
        var fBotBuilder = services.AddOneBotV11(section);
        services.AddNapCatInternal();
        return fBotBuilder;
    }

    private static void AddNapCatInternal(this IServiceCollection services)
    {
        services.AddSingleton<NapCatAdapter>();
    }

    public static IEndpointRouteBuilder UseNapCat(
        this IEndpointRouteBuilder endpoints,
        CancellationToken cancellationToken = default
    )
    {
        var adapter = endpoints.ServiceProvider.GetRequiredService<NapCatAdapter>();
        adapter.Init(endpoints, cancellationToken);
        return endpoints;
    }
}
