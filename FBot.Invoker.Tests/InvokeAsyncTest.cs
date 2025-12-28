using FBot.Invoker.Tests.Models;
using Microsoft.Extensions.DependencyInjection;

namespace FBot.Invoker.Tests;

public class InvokeAsyncTest
{
    private readonly ServiceProviderOptions _buildOptions = new()
    {
        ValidateOnBuild = true,
        ValidateScopes = true,
    };

    [Fact]
    public async Task TestInvoke1Async()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryDependent>();
        await using var serviceProvider = serviceCollection.BuildServiceProvider(
            options: _buildOptions
        );
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = await invoker.InvokeAsync(
            ([FromDictionary] string key1) => Task.FromResult(key1)
        );
        Assert.True(result is { IsValid: true, Value: "value1" });
    }

    [Fact]
    public async Task TestInvoke2Async()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryDependent>();
        await using var serviceProvider = serviceCollection.BuildServiceProvider(
            options: _buildOptions
        );
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = await invoker.InvokeAsync(
            ([FromDictionary("key2")] string value) => Task.FromResult(value)
        );
        Assert.True(result is { IsValid: true, Value: "value2" });
    }

    [Fact]
    public async Task TestInvoke3Async()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryDependent>();
        await using var serviceProvider = serviceCollection.BuildServiceProvider(
            options: _buildOptions
        );
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = await invoker.InvokeAsync(
            ([FromDependent(typeof(DictionaryDependent))] Dictionary<string, object?> dict) =>
                Task.FromResult(dict)
        );
        var value = (Dictionary<string, object?>)result.Value!;
        Assert.True(result.IsValid);
        Assert.Equal(value["key1"], "value1");
    }
}
