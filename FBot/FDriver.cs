using FBot.Invoker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FBot;

public class FDriver
{
    public List<FDependentMethod> EventCallbackMethods { get; } = [];

    public IServiceProvider ServiceProvider { get; }

    public ILogger<FDriver>? Logger { get; }

    public FDriver(ILogger<FDriver> logger, IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
        Logger = logger;
    }

    public FDriver(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    public async Task<FResponse> RunEventMethodsAsync(
        IBot bot,
        IEvent @event,
        CancellationToken cancellationToken = default
    )
    {
        List<Task> tasks = [];
        var response = new FResponse();
        foreach (var eventMethod in EventCallbackMethods)
        {
            tasks.Add(RunOnceAsync(bot, @event, response, eventMethod, cancellationToken));
        }

        await Task.WhenAll(tasks);
        return response;
    }

    public void RunEventMethodsBackground(
        IBot bot,
        IEvent @event,
        CancellationToken cancellationToken = default
    )
    {
        Task.Run(
            async () => await RunEventMethodsAsync(bot, @event, cancellationToken),
            cancellationToken
        );
    }

    private async Task RunOnceAsync(
        IBot bot,
        IEvent @event,
        FResponse response,
        FDependentMethod dependentMethod,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            using var scope = ServiceProvider.CreateScope();
            var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
            var context = new FContext(bot, @event, response)
            {
                ServiceProvider = scope.ServiceProvider,
            };
            if (!await dependentMethod.Rule.IsMatchAsync(context))
            {
                return;
            }
            if (dependentMethod.IsAsync)
            {
                await invoker.InvokeAsync(dependentMethod, context, null);
            }
            else
            {
                await Task.Run(
                    () => invoker.Invoke(dependentMethod, context, null),
                    cancellationToken
                );
            }
        }
        catch (Exception e)
        {
            Logger?.LogError(e, "exception raised");
        }
    }
}

public static class FDriverExtensions
{
    public static IFDriverBuilder AddFBot(this IServiceCollection services)
    {
        var invokerBuilder = services
            .AddDependentInvoker()
            .AddDefaultSubTypesDependent<IBot, FBotDependent>()
            .AddDefaultSubTypesDependent<IEvent, FEventDependent>();
        var builder =
            GetServiceFromCollection<IFDriverBuilder>(services)
            ?? new FDriverBuilder(services, invokerBuilder);
        services.TryAddSingleton<IFDriverBuilder>(builder);
        services.TryAddSingleton<FDriver>();
        services.TryAddSingleton<FBotDependent>();
        services.TryAddSingleton<FEventDependent>();
        return builder;
    }

    public static FDriver GetFDriver(this IHost host)
    {
        var driver = host.Services.GetService<FDriver>();
        if (driver is null)
        {
            throw new InvalidOperationException("FDriver service is not registered");
        }

        return driver;
    }

    public static FDriver MapEventCallbackMethods(
        this FDriver driver,
        FDependentMethod dependentMethod
    )
    {
        driver.EventCallbackMethods.Add(dependentMethod);
        return driver;
    }

    public static FDriver MapEventCallbackMethods(this FDriver driver, Delegate del)
    {
        return MapEventCallbackMethods(driver, del, FRule.EmptyRule);
    }

    public static FDriver MapEventCallbackMethods(this FDriver driver, Delegate del, IFRule rule)
    {
        var dependentMethod = new FDependentMethod(del.Method, (_, _) => del.Target, rule);
        driver.EventCallbackMethods.Add(dependentMethod);
        return driver;
    }

    internal static T? GetServiceFromCollection<T>(this IServiceCollection services)
    {
        return (T?)services.LastOrDefault(d => d.ServiceType == typeof(T))?.ImplementationInstance;
    }
}
