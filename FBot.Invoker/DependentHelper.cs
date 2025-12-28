using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FBot.Invoker;

public static class DependentHelper
{
    /// <summary>
    /// <para>检查是否应该使用async</para>
    /// 当返回值为以下情况时，应该使用异步运行方法：<br />
    /// 1. 返回值为 <see cref="Task"/> 或 <see cref="Task{T}"/> 的子类型<br />
    /// 2. 返回值为 <see cref="ValueTask"/> 或 <see cref="ValueTask{T}"/><br />
    /// 3. 方法带有 <c>async</c> 标记，即 <see cref="AsyncStateMachineAttribute"/><br />
    /// 4. 返回的类符合异步的定义，即具有合适的 `GetAwaiter` 方法
    /// </summary>
    /// <param name="methodInfo">methodInfo</param>
    /// <param name="returnType">返回类型</param>
    /// <returns></returns>
    public static bool CheckIsAsync(MethodInfo methodInfo, out Type returnType)
    {
        var nowType = methodInfo.ReturnType;
        // 先判断是否是ValueTask
        if (nowType == typeof(ValueTask))
        {
            returnType = typeof(void);
            return true;
        }
        if (nowType.IsGenericType && nowType.GetGenericTypeDefinition() == typeof(ValueTask<>))
        {
            returnType = nowType.GetGenericArguments()[0];
            return true;
        }
        // 判断是否是Task
        while (nowType != null)
        {
            if (nowType.IsGenericType && nowType.GetGenericTypeDefinition() == typeof(Task<>))
            {
                returnType = nowType.GetGenericArguments()[0];
                return true;
            }
            if (nowType == typeof(Task))
            {
                returnType = typeof(void);
                return true;
            }
            nowType = nowType.BaseType;
        }

        // 判断是否有async标记
        var isAsync = methodInfo.GetCustomAttribute<AsyncStateMachineAttribute>() is not null;
        if (isAsync)
        {
            // async void
            if (methodInfo.ReturnType == typeof(void))
            {
                returnType = typeof(void);
                return true;
            }
        }

        // 具有合适的 GetAwaiter 方法
        if (IsValidAwaitableType(methodInfo.ReturnType, out var rType))
        {
            returnType = rType;
            return true;
        }

        // 不是 async 方法
        returnType = methodInfo.ReturnType;
        return false;
    }

    public static bool IsValidAwaitableType(Type type, [NotNullWhen(true)] out Type? returnType)
    {
        var getAwaiterMethod = type.GetMethod(
            "GetAwaiter",
            BindingFlags.Public | BindingFlags.Instance,
            []
        );
        if (getAwaiterMethod is null)
        {
            returnType = null;
            return false;
        }
        var awaiterType = getAwaiterMethod.ReturnType;
        var getResultMethod = awaiterType.GetMethod(
            "GetResult",
            BindingFlags.Public | BindingFlags.Instance,
            []
        );
        var isCompletedProperty = awaiterType.GetProperty(
            "IsCompleted",
            BindingFlags.Public | BindingFlags.Instance
        );
        var hasINotifyCompletion = typeof(INotifyCompletion).IsAssignableFrom(awaiterType);
        if (
            hasINotifyCompletion
            && getResultMethod is not null
            && isCompletedProperty is not null
            && isCompletedProperty.CanRead
        )
        {
            // 是异步类型
            returnType = getResultMethod.ReturnType;
            return true;
        }

        returnType = null;
        return false;
    }
}
