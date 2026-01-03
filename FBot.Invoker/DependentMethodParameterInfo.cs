using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace FBot.Invoker;

public enum DependentParameterInfoFrom
{
    DependentCall,
    DependentInvokerInfo,
}

public class DependentParameterInfo
{
    public DependentParameterInfo(Type dependentType, object?[] args, bool? useCache = null)
    {
        if (!typeof(IDependent).IsAssignableFrom(dependentType))
        {
            throw new NotSupportedException();
        }
        DependentType = dependentType;
        Args = args;
        UseCache = useCache;
    }

    public Type DependentType { get; }

    public object?[] Args { get; }

    public bool? UseCache { get; }
}

public class DependentMethodParameterInfo
{
    public DependentMethod DependentMethod { get; }

    public ParameterInfo ParameterInfo { get; }

    public bool IsNullable { get; }

    public DependentParameterInfoFrom From { get; }

    public List<DependentParameterInfo> DependentTypes { get; } = [];

    public DependentMethodParameterInfo(
        DependentMethod dependentMethod,
        ParameterInfo parameterInfo,
        DependentInvokerOptions options
    )
    {
        DependentMethod = dependentMethod;
        ParameterInfo = parameterInfo;
        var attributes = parameterInfo.GetCustomAttributes();
        IsNullable = ReflectionHelper.IsParameterNullable(parameterInfo);
        bool hasDependentAttribute = false;
        foreach (var attribute in attributes)
        {
            switch (attribute)
            {
                case FromDependentAttribute attr:
                    DependentTypes.Add(
                        new DependentParameterInfo(
                            attr.DependentType,
                            attr.Args,
                            attr.UseCacheOptional
                        )
                    );
                    break;
                case FromKeyedServicesAttribute attr:
                    DependentTypes.Add(
                        new DependentParameterInfo(typeof(FromKeyedServiceDependent), [attr.Key])
                    );
                    break;
                default:
                    continue;
            }

            hasDependentAttribute = true;
            From = DependentParameterInfoFrom.DependentCall;
        }

        if (hasDependentAttribute)
        {
            return;
        }

        // 没有任何要使用Dependent的标记
        if (typeof(IDependent).IsAssignableFrom(parameterInfo.ParameterType))
        {
            // 直接获取Dependent本身
            DependentTypes.Add(new DependentParameterInfo(typeof(FromServiceDependent), []));
            From = DependentParameterInfoFrom.DependentCall;
        }
        else if (parameterInfo.ParameterType == typeof(DependentInvokeInfo))
        {
            From = DependentParameterInfoFrom.DependentInvokerInfo;
        }
        else
        {
            // 判断是否是内置类型
            if (
                !options.DependentConverters.TryGetValue(
                    parameterInfo.ParameterType,
                    out var dependentTypes
                )
            )
            {
                // 不是内置类型，尝试从依赖注入获取
                DependentTypes.Add(new DependentParameterInfo(typeof(FromServiceDependent), []));
                From = DependentParameterInfoFrom.DependentCall;
                return;
            }
            // 是内置类型，使用内置类型
            DependentTypes.AddRange(
                dependentTypes.Select(dependentType => new DependentParameterInfo(
                    dependentType,
                    []
                ))
            );
            From = DependentParameterInfoFrom.DependentCall;
        }
    }
}
