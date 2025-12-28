using System.Runtime.CompilerServices;

namespace FBot.Invoker.Tests;

public class DependentMethodTest
{
    [Fact]
    public void TestVoid()
    {
        var method = new DependentMethod(FuncVoid);
        var methodAsync = new DependentMethod(FuncVoidAsync);

        Assert.False(method.IsAsync);
        Assert.Equal(typeof(void), method.ReturnType);

        Assert.True(methodAsync.IsAsync);
        Assert.Equal(typeof(void), methodAsync.ReturnType);
    }

    [Fact]
    public void TestInt()
    {
        var method = new DependentMethod(FuncInt);
        var methodAsync = new DependentMethod(FuncIntAsync);

        Assert.False(method.IsAsync);
        Assert.Equal(typeof(int), method.ReturnType);

        Assert.True(methodAsync.IsAsync);
        Assert.Equal(typeof(int), methodAsync.ReturnType);
    }

    [Fact]
    public void TestParameters1()
    {
        var method = new DependentMethod(FuncWithParameters1);
        var options = new DependentInvokerOptions();
        var parameters = method.GetParameters(options);
        Assert.Single(parameters);
        var p = parameters[0];
        Assert.False(p.IsNullable);
        Assert.Equal("i", p.ParameterInfo.Name);
    }

    [Fact]
    public void TestParameters2()
    {
        var method = new DependentMethod(FuncWithParameters2);
        var options = new DependentInvokerOptions();
        var parameters = method.GetParameters(options);
        Assert.Equal(4, parameters.Length);
        // int i
        Assert.False(parameters[0].IsNullable);
        Assert.Equal("i", parameters[0].ParameterInfo.Name);
        // int? iNull
        Assert.True(parameters[1].IsNullable);
        Assert.Equal("iNull", parameters[1].ParameterInfo.Name);
        // string s
        Assert.False(parameters[2].IsNullable);
        Assert.Equal("s", parameters[2].ParameterInfo.Name);
        // string? sNull
        Assert.True(parameters[3].IsNullable);
        Assert.Equal("sNull", parameters[3].ParameterInfo.Name);
    }

    [Fact]
    public void TestIntNull()
    {
        var method = new DependentMethod(FuncIntNull);
        var methodAsync = new DependentMethod(FuncIntNullAsync);

        Assert.False(method.IsAsync);
        Assert.Equal(typeof(int?), method.ReturnType);

        Assert.True(methodAsync.IsAsync);
        Assert.Equal(typeof(int?), methodAsync.ReturnType);
    }

    [Fact]
    public void TestAwaitableVoid()
    {
        var method = new DependentMethod(FuncAwaitableVoid);

        Assert.True(method.IsAsync);
        Assert.Equal(typeof(void), method.ReturnType);
    }

    [Fact]
    public void TestAwaitableInt()
    {
        var method = new DependentMethod(FuncAwaitableInt);

        Assert.True(method.IsAsync);
        Assert.Equal(typeof(int), method.ReturnType);
    }

    [Fact]
    public void TestAwaitableIntNull()
    {
        var method = new DependentMethod(FuncAwaitableIntNull);

        Assert.True(method.IsAsync);
        Assert.Equal(typeof(int?), method.ReturnType);
    }

    [Fact]
    public void TestFuncAwaitableTask()
    {
        var method = new DependentMethod(FuncAwaitableTask);

        Assert.True(method.IsAsync);
        Assert.Equal(typeof(Task), method.ReturnType);
    }

    [Fact]
    public void TestFuncAwaitableTaskAsync()
    {
        var method = new DependentMethod(FuncAwaitableTaskAsync);

        Assert.True(method.IsAsync);
        Assert.Equal(typeof(Task), method.ReturnType);
    }

    internal void FuncVoid() { }

    internal Task FuncVoidAsync() => Task.CompletedTask;

    internal int FuncInt() => 1;

    internal Task<int> FuncIntAsync() => Task.FromResult(1);

    internal int? FuncIntNull() => 1;

    internal Task<int?> FuncIntNullAsync() => Task.FromResult((int?)1);

    internal void FuncWithParameters1(int i) { }

    internal void FuncWithParameters2(int i, int? iNull, string s, string? sNull) { }

    internal AwaitableVoid FuncAwaitableVoid() => new();

    internal AwaitableInt FuncAwaitableInt() => new();

    internal AwaitableIntNull FuncAwaitableIntNull() => new();

    internal AwaitableTask FuncAwaitableTask() => new();

    internal AwaitableTaskAsync FuncAwaitableTaskAsync() => new();

    public class AwaitableVoid
    {
        // 1. 必须有一个 GetAwaiter() 方法
        public Awaiter GetAwaiter() => new Awaiter();

        // 2. 定义内部的 Awaiter 结构
        public struct Awaiter : INotifyCompletion
        {
            public bool IsCompleted => true;

            public void OnCompleted(Action continuation) => continuation();

            public void GetResult() { }
        }
    }

    public class AwaitableInt
    {
        public Awaiter GetAwaiter() => new Awaiter();

        public struct Awaiter : INotifyCompletion
        {
            public bool IsCompleted => true;

            public void OnCompleted(Action continuation) => continuation();

            public int GetResult() => 1;
        }
    }

    public class AwaitableIntNull
    {
        public Awaiter GetAwaiter() => new Awaiter();

        public struct Awaiter : INotifyCompletion
        {
            public bool IsCompleted => true;

            public void OnCompleted(Action continuation) => continuation();

            public int? GetResult() => 1;
        }
    }

    public class AwaitableTask
    {
        public Awaiter GetAwaiter() => new Awaiter();

        public struct Awaiter : INotifyCompletion
        {
            public bool IsCompleted => true;

            public void OnCompleted(Action continuation) => continuation();

            public Task GetResult() => Task.CompletedTask;
        }
    }

    public class AwaitableTaskAsync
    {
        public Awaiter GetAwaiter() => new Awaiter();

        public struct Awaiter : INotifyCompletion
        {
            public bool IsCompleted => true;

            public void OnCompleted(Action continuation) => continuation();

            public async Task GetResult() { }
        }
    }
}
