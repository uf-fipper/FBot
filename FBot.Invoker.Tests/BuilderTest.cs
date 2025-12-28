using FBot.Invoker.Tests.Models;
using Microsoft.Extensions.DependencyInjection;

namespace FBot.Invoker.Tests;

public class BuilderTest
{
    private readonly ServiceProviderOptions _buildOptions = new()
    {
        ValidateOnBuild = true,
        ValidateScopes = true,
    };

    [Fact]
    public void TestCreateInvoker()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        Assert.Equal(
            typeof(ContextDependent),
            invoker.Options.DependentConverters[typeof(IDependentContext)][0]
        );
        Assert.Equal(
            typeof(ContextDependent),
            invoker.Options.DependentConverters[typeof(DependentContext)][0]
        );
    }

    [Fact]
    public void TestCreateInvokerWithConverters()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddDependentInvoker()
            .AddDependentConverter(
                typeof(Dictionary<string, object?>),
                typeof(DictionaryDependent)
            );
        serviceCollection.AddSingleton<DictionaryDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var dictionaryDependent = invoker.Options.DependentConverters[
            typeof(Dictionary<string, object?>)
        ][0];
        Assert.Equal(typeof(DictionaryDependent), dictionaryDependent);
    }

    [Fact]
    public void TestCreateInvokerWithMultipleConverters()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddDependentInvoker()
            .AddDependentConverter(typeof(Dictionary<string, object?>), typeof(DictionaryDependent))
            .AddDependentConverter(
                typeof(Dictionary<string, object?>),
                typeof(DictionaryDependent)
            );
        serviceCollection.AddSingleton<DictionaryDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var dictionaryDependent0 = invoker.Options.DependentConverters[
            typeof(Dictionary<string, object?>)
        ][0];
        var dictionaryDependent1 = invoker.Options.DependentConverters[
            typeof(Dictionary<string, object?>)
        ][0];
        Assert.Equal(typeof(DictionaryDependent), dictionaryDependent0);
        Assert.Equal(typeof(DictionaryDependent), dictionaryDependent1);
    }
}
