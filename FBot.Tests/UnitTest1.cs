using FBot.Tests.Models.FTest1;
using Microsoft.Extensions.DependencyInjection;

namespace FBot.Tests;

public class UnitTest1
{
    private readonly ServiceProviderOptions _serviceProviderOptions = new()
    {
        ValidateScopes = true,
        ValidateOnBuild = true,
    };

    private List<int> IsRun { get; } = [];

    private void Run1(IBot bot, IEvent ev)
    {
        Assert.True(bot is FTest1Bot);
        Assert.True(ev is FTest1Event);
        IsRun.Add(1);
    }

    private void Run2(FTest1Bot bot, FTest1Event ev)
    {
        IsRun.Add(2);
    }

    private void Run3()
    {
        IsRun.Add(3);
    }

    private void Run4(FTest1Bot bot, FTest1Event ev, FContext context)
    {
        IsRun.Add(4);
    }

    private void RunResponse(FTest1Bot bot, FTest1Event ev, FContext context)
    {
        context.Response.SetResponse(bot.BotValue + ev.EventValue);
    }

    [Fact]
    public async Task Test1Async()
    {
        var serviceCollection = new ServiceCollection();
        var builder = serviceCollection.AddFBot();
        var serviceProvider = serviceCollection.BuildServiceProvider(_serviceProviderOptions);
        var driver = serviceProvider.GetRequiredService<FDriver>();
        driver.MapEventCallbackMethods(Run1);
        driver.MapEventCallbackMethods(Run2);
        driver.MapEventCallbackMethods(Run3);
        driver.MapEventCallbackMethods(Run4);
        var bot = new FTest1Bot();
        var ev = new FTest1Event();
        await driver.RunEventMethodsAsync(bot, ev);
        Assert.Contains(1, IsRun);
        Assert.Contains(2, IsRun);
        Assert.Contains(3, IsRun);
        Assert.Contains(4, IsRun);
    }

    [Fact]
    public async Task TestResponseAsync()
    {
        var serviceCollection = new ServiceCollection();
        var builder = serviceCollection.AddFBot();
        var serviceProvider = serviceCollection.BuildServiceProvider(_serviceProviderOptions);
        var driver = serviceProvider.GetRequiredService<FDriver>();
        driver.MapEventCallbackMethods(RunResponse);
        var bot = new FTest1Bot() { BotValue = 1 };
        var ev = new FTest1Event() { EventValue = 2 };
        var response = await driver.RunEventMethodsAsync(bot, ev);
        Assert.True(response.HasResponse);
        Assert.Equal(3, response.Value);
    }
}
