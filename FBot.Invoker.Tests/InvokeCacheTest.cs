using FBot.Invoker.Tests.Models;
using Microsoft.Extensions.DependencyInjection;

namespace FBot.Invoker.Tests;

public class InvokeCacheTest
{
    private readonly ServiceProviderOptions _buildOptions = new()
    {
        ValidateOnBuild = true,
        ValidateScopes = true,
    };

    [Fact]
    public void TestInvokeWithCache()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryWithCacheDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = invoker.Invoke(
            ([FromDictionaryWithCache] string key1, [FromDictionaryWithCache] string key2) =>
            {
                Assert.Equal("value1", key1);
                // key2 should have the same value as key1 due to caching
                Assert.Equal("value1", key2);
                return 1;
            }
        );
        Assert.True(result is { IsValid: true, Value: 1 });
    }

    [Fact]
    public void TestInvokeWithCacheInAttribute1()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = invoker.Invoke(
            (
                [FromDictionary(UseCache = true)] string key1,
                [FromDictionary(UseCache = true)] string key2
            ) =>
            {
                Assert.Equal("value1", key1);
                // key2 should have the same value as key1 due to caching
                Assert.Equal("value1", key2);
                return 1;
            }
        );
        Assert.True(result is { IsValid: true, Value: 1 });
    }

    [Fact]
    public void TestInvokeWithCacheInAttribute2()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryWithCacheDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = invoker.Invoke(
            (
                [FromDictionaryWithCache(UseCache = false)] string key1,
                [FromDictionaryWithCache(UseCache = false)] string key2
            ) =>
            {
                Assert.Equal("value1", key1);
                // key2 should not be cached and should have a different value
                Assert.Equal("value2", key2);
                return 1;
            }
        );
        Assert.True(result is { IsValid: true, Value: 1 });
    }
}
