using FBot.Invoker.Tests.Models;
using Microsoft.Extensions.DependencyInjection;

namespace FBot.Invoker.Tests;

public class InvokeTest
{
    private readonly ServiceProviderOptions _buildOptions = new()
    {
        ValidateOnBuild = true,
        ValidateScopes = true,
    };

    private List<int> _state = [];

    [Fact]
    public void TestInvoke1()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = invoker.Invoke(([FromDictionary] string key1) => key1);
        Assert.True(result is { IsValid: true, Value: "value1" });
    }

    [Fact]
    public void TestInvoke2()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = invoker.Invoke(([FromDictionary("key2")] string value) => value);
        Assert.True(result is { IsValid: true, Value: "value2" });
    }

    [Fact]
    public void TestInvoke3()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = invoker.Invoke(
            ([FromDependent(typeof(DictionaryDependent))] Dictionary<string, object?> dict) => dict
        );
        var value = (Dictionary<string, object?>)result.Value!;
        Assert.True(result.IsValid);
        Assert.Equal(value["key1"], "value1");
    }

    [Fact]
    public void TestInvokeEmpty()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = invoker.Invoke(() => "value");
        Assert.True(result is { IsValid: true, Value: "value" });
    }

    [Fact]
    public void TestInvokeMultipleArgs1()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = invoker.Invoke(
            ([FromDictionary] string key1, [FromDictionary("key2")] string value2) =>
                $"{key1}-{value2}"
        );
        Assert.True(result is { IsValid: true, Value: $"value1-value2" });
    }

    [Fact]
    public void TestInvokeMultipleArgs2()
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
                [FromDictionary] string key1,
                [FromDictionary("key2")] string value2,
                [FromDependent(typeof(FromDictionaryDependent), ["key1"])] string key11
            ) => new object[] { key1, value2, key11 }
        );
        Assert.True(
            result is { IsValid: true, Value: object?[] and ["value1", "value2", "value1"] }
        );
    }

    [Fact]
    public void TestInvokeVoid()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        int a = 1;
        var result = invoker.Invoke(() =>
        {
            a = 2;
        });
        Assert.True(result is { IsValid: false, Value: null });
        Assert.Equal(2, a);
    }

    [Fact]
    public void TestInvokeVoidWithMethod()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        string a = "";
        var result = invoker.Invoke(
            ([FromDictionary("key1")] string value) =>
            {
                a = value;
            }
        );
        Assert.True(result is { IsValid: false, Value: null });
        Assert.Equal("value1", a);
    }

    [Fact]
    public void TestInvokeNullable1()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = invoker.Invoke(([FromDictionary("nullKey")] string value) => value);
        Assert.True(result is { IsValid: false, Value: null });
    }

    [Fact]
    public void TestInvokeNullable2()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = invoker.Invoke(([FromDictionary("nullKey")] string? value) => value);
        Assert.True(result is { IsValid: true, Value: null });
    }

    [Fact]
    public void TestInvokeNullable3()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = invoker.Invoke(([FromDictionary("nullKey")] int? value) => value);
        Assert.True(result is { IsValid: true, Value: null });
    }

    [Fact]
    public void TestInvokeNullable4()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result1 = invoker.Invoke(([FromDictionary("int1")] int? value) => value);
        Assert.True(result1 is { IsValid: true, Value: 1 });
        var result2 = invoker.Invoke(([FromDictionary] int? int2) => int2);
        Assert.True(result2 is { IsValid: true, Value: 2 });
    }

    [Fact]
    public void TestInvokeInvalid1()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = invoker.Invoke((string key1) => key1);
        Assert.True(result is { IsValid: false, Value: null });
    }

    [Fact]
    public void TestInvokeInvalid2()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = invoker.Invoke(([FromDictionary("invalidKey")] string key) => key);
        Assert.True(result is { IsValid: false, Value: null });
    }

    [Fact]
    public void TestInvokeInvalid3()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        // no service for FromDictionaryDependent
        var result = invoker.Invoke(([FromDictionary("invalidKey")] string key) => key);
        Assert.True(result is { IsValid: false, Value: null });
    }

    [Fact]
    public void TestInvokeContext1()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = invoker.Invoke((IDependentContext context) => context.ServiceProvider);
        Assert.True(
            result is { IsValid: true, Value: IServiceProvider ctx } && ctx == scope.ServiceProvider
        );
    }

    [Fact]
    public void TestInvokeContext2()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = invoker.Invoke((DependentContext context) => context.ServiceProvider);
        Assert.True(
            result is { IsValid: true, Value: IServiceProvider ctx } && ctx == scope.ServiceProvider
        );
    }

    [Fact]
    public void TestInvokeMethod()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = invoker.Invoke(([FromDictionary("invalidKey")] string key) => key);
        Assert.True(result is { IsValid: false, Value: null });
    }

    [Fact]
    public void TestInvokeStaticMethod()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = invoker.Invoke(StaticMethod);
        Assert.True(result is { IsValid: true, Value: 1 });
    }

    [Fact]
    public void TestInvokeHasThisMethod()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = invoker.Invoke(HasThisMethod);
        Assert.True(result is { IsValid: true, Value: 1 });
    }

    [Fact]
    public void TestInvokeLocalMethod()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = invoker.Invoke(LocalMethod);
        Assert.True(result is { IsValid: true, Value: 1 });
        return;

        int LocalMethod([FromDictionary] string key1, [FromDictionary] string key2)
        {
            Assert.Equal("value1", key1);
            Assert.Equal("value2", key2);
            return 1;
        }
    }

    [Fact]
    public void TestInvokeLocalStaticMethod()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDependentInvoker();
        serviceCollection.AddSingleton<DictionaryDependent>();
        serviceCollection.AddScoped<FromDictionaryDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        using var scope = serviceProvider.CreateScope();
        var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
        var result = invoker.Invoke(LocalStaticMethod);
        Assert.True(result is { IsValid: true, Value: 1 });
        return;

        static int LocalStaticMethod([FromDictionary] string key1, [FromDictionary] string key2)
        {
            Assert.Equal("value1", key1);
            Assert.Equal("value2", key2);
            return 1;
        }
    }

    [Fact]
    public void TestInvokeScope()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddDependentInvoker()
            .AddDependentConverter<SubDependentContext, ContextDependent>();
        serviceCollection.AddScoped<SubStateDependent>();
        using var serviceProvider = serviceCollection.BuildServiceProvider(options: _buildOptions);
        TestSubState("value1", 1);
        TestSubState("value2", 2);

        return;

        void TestSubState(string sValue, int iValue)
        {
            using var scope = serviceProvider.CreateScope();
            var invoker = scope.ServiceProvider.GetRequiredService<IDependentInvoker>();
            var state = new SubDependentContext(sValue, iValue)
            {
                ServiceProvider = scope.ServiceProvider,
            };
            var result = invoker.Invoke(TestState, state);
            Assert.True(result is { IsValid: true, Value: 10 });
            return;

            int TestState(
                SubDependentContext subContext,
                [FromSubState] int a,
                [FromSubState] string s
            )
            {
                Assert.Equal(subContext.IntValue, a);
                Assert.Equal(subContext.StringValue, s);
                return 10;
            }
        }
    }

    private static int StaticMethod([FromDictionary] string key1, [FromDictionary] string key2)
    {
        Assert.Equal("value1", key1);
        Assert.Equal("value2", key2);
        return 1;
    }

    private int HasThisMethod([FromDictionary("key1")] string key1, [FromDictionary] string key2)
    {
        Assert.Equal("value1", key1);
        Assert.Equal("value2", key2);
        return 1;
    }
}
