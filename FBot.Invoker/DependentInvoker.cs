namespace FBot.Invoker;

public interface IDependentInvoker
{
    DependentInvokerOptions Options { get; }

    IDependentResult Invoke(
        DependentMethod dependentMethod,
        IDependentContext? context = null,
        DependentInvokeInfo? info = null
    );

    Task<IDependentResult> InvokeAsync(
        DependentMethod dependentMethod,
        IDependentContext? context = null,
        DependentInvokeInfo? info = null
    );
}

public class DependentInvoker(DependentInvokerOptions options, IServiceProvider serviceProvider)
    : IDependentInvoker
{
    public DependentInvokerOptions Options => options;

    public IDependentResult Invoke(
        DependentMethod dependentMethod,
        IDependentContext? context,
        DependentInvokeInfo? info
    )
    {
        context ??= new DependentContext() { ServiceProvider = serviceProvider };
        if (dependentMethod.IsAsync)
        {
            return Task.Run(async () => await InvokeInternalAsync(dependentMethod, context, info))
                .GetAwaiter()
                .GetResult();
        }
        else
        {
            return InvokeInternal(dependentMethod, context, info);
        }
    }

    public async Task<IDependentResult> InvokeAsync(
        DependentMethod dependentMethod,
        IDependentContext? context,
        DependentInvokeInfo? info
    )
    {
        context ??= new DependentContext() { ServiceProvider = serviceProvider };
        if (dependentMethod.IsAsync)
        {
            return await InvokeInternalAsync(dependentMethod, context, info);
        }
        else
        {
            return await Task.FromResult(InvokeInternal(dependentMethod, context, info));
        }
    }

    private IDependentResult InvokeInternal(
        DependentMethod dependentMethod,
        IDependentContext context,
        DependentInvokeInfo? info
    )
    {
        object? obj = dependentMethod.GetTarget(context, info);
        var paramResults = CreateParams(dependentMethod, context, info);
        if (paramResults is null)
        {
            return DependentResult.Invalid();
        }

        if (dependentMethod.ReturnType == typeof(void))
        {
            dependentMethod.MethodInfo.Invoke(obj, paramResults);
            return DependentResult.Invalid();
        }

        var result = dependentMethod.MethodInfo.Invoke(obj, paramResults)!;
        return ConvertResult(result);
    }

    private async Task<IDependentResult> InvokeInternalAsync(
        DependentMethod dependentMethod,
        IDependentContext context,
        DependentInvokeInfo? info
    )
    {
        await Task.CompletedTask;
        object? obj = dependentMethod.GetTarget(context, info);
        var paramResults = CreateParams(dependentMethod, context, info);
        if (paramResults is null)
        {
            return DependentResult.Invalid();
        }

        if (dependentMethod.ReturnType == typeof(void))
        {
            await (Task)dependentMethod.MethodInfo.Invoke(obj, paramResults)!;
            return DependentResult.Invalid();
        }

        var result = await (dynamic)dependentMethod.MethodInfo.Invoke(obj, paramResults)!;
        return ConvertResult(result);
    }

    private object?[]? CreateParams(
        DependentMethod dependentMethod,
        IDependentContext context,
        DependentInvokeInfo? info
    )
    {
        var parameterInfos = dependentMethod.GetParameters(Options);
        var paramResults = new object?[parameterInfos.Length];
        for (int i = 0; i < parameterInfos.Length; i++)
        {
            var pResult = CreateParam(parameterInfos[i], context, info);
            if (!pResult.IsValid)
            {
                return null;
            }
            paramResults[i] = pResult.Value;
        }
        return paramResults;
    }

    private IDependentResult CreateParam(
        DependentMethodParameterInfo parameterInfo,
        IDependentContext context,
        DependentInvokeInfo? info
    )
    {
        if (parameterInfo.From == DependentParameterInfoFrom.DependentInvokerInfo)
        {
            return DependentResult.Valid(info);
        }
        foreach (var dependentParameterInfo in parameterInfo.DependentTypes)
        {
            var obj = (IDependent?)serviceProvider.GetService(dependentParameterInfo.DependentType);
            if (obj is null)
            {
                if (Options.ThrowIfNoService)
                {
                    throw new NotSupportedException();
                }
                return DependentResult.Invalid();
            }
            var useCache = dependentParameterInfo.UseCache ?? obj.UseCache;
            if (useCache)
            {
                // 从缓存中获取
                if (
                    context.CachedDependents.TryGetValue(
                        dependentParameterInfo.DependentType,
                        out var cachedValue
                    )
                )
                {
                    var cachedResult = ConvertResult(cachedValue, parameterInfo);
                    if (cachedResult.IsValid)
                    {
                        return cachedResult;
                    }
                    return DependentResult.Invalid();
                }
            }
            var subInfo = new DependentInvokeInfo(
                parameterInfo.ParameterInfo,
                dependentParameterInfo.Args
            );
            var result = obj.Invoke(context, subInfo);
            if (useCache)
            {
                // 存入缓存
                context.CachedDependents[dependentParameterInfo.DependentType] = result.Value;
            }
            result = ConvertResult(result, parameterInfo);
            if (result.IsValid)
            {
                return result;
            }
        }
        return DependentResult.Invalid();
    }

    private DependentResult ConvertResult(
        object? value,
        DependentMethodParameterInfo? parameterInfo = null
    )
    {
        // 如果返回值已经invalid，则直接返回
        if (value is IDependentResult resultValue)
        {
            if (!resultValue.IsValid)
            {
                return DependentResult.Invalid();
            }
            value = resultValue.Value;
        }
        // 进行null性判断
        if (value is null)
        {
            if (parameterInfo?.IsNullable is false)
            {
                return DependentResult.Invalid();
            }
            return DependentResult.Valid(null);
        }
        // 判断类型是否匹配
        var pType = parameterInfo?.ParameterInfo.ParameterType;
        if (pType is null || pType.IsInstanceOfType(value))
        {
            return DependentResult.Valid(value);
        }

        try
        {
            // 类型不匹配，则尝试进行类型转换
            value = Convert.ChangeType(value, pType);
            return DependentResult.Valid(value);
        }
        catch (InvalidCastException)
        {
            return DependentResult.Invalid();
        }
    }
}

public static class DependentInvokerExtensions
{
    #region Invoke

    public static IDependentResult Invoke(
        this IDependentInvoker invoker,
        Delegate del,
        IDependentContext? context = null,
        DependentInvokeInfo? info = null
    ) => invoker.Invoke(new DependentMethod(del), context, info);

    #endregion

    #region InvokeAsync

    public static Task<IDependentResult> InvokeAsync(
        this IDependentInvoker invoker,
        Delegate del,
        IDependentContext? context = null,
        DependentInvokeInfo? info = null
    ) => invoker.InvokeAsync(new DependentMethod(del), context, info);

    #endregion
}
