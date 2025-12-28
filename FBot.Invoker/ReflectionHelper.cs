using System.Collections.Concurrent;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;

namespace FBot.Invoker;

/// <summary>
/// 反射相关方法
/// </summary>
public static class ReflectionHelper
{
    /// <summary>
    /// 获取引用了<paramref name="assembly"/>程序集的所有的程序集
    /// </summary>
    /// <param name="assembly">引用这个程序集</param>
    /// <param name="dependencyContext">依赖上下文,null则使用默认</param>
    /// <returns></returns>
    public static List<Assembly> GetReferredAssemblies(
        Assembly assembly,
        DependencyContext? dependencyContext = null
    )
    {
        dependencyContext ??=
            DependencyContext.Default ?? throw new ArgumentNullException(nameof(dependencyContext));

        var res = CacheAssemblyReferred.GetOrDefault(assembly);
        if (res is not null)
            return res;

        var allLib = dependencyContext.RuntimeLibraries.OrderBy(r => r.Name).ToList();

        var name = assembly.GetName().Name;
        if (name is null)
            return [];

        Dictionary<string, HashSet<string>> allDependencies = [];
        foreach (var item in allLib)
        {
            allDependencies.Add(item.Name, []);
            LoadAllDependency(allLib, item.Name, [], item, allDependencies);
        }

        var list = allDependencies
            .Where(r => r.Value.Contains(name))
            .Select(r =>
            {
                try
                {
                    return Assembly.Load(r.Key);
                }
                catch
                {
                    return null;
                }
            })
            .Where(r => r is not null)
            .ToList();

        res = list!;
        CacheAssemblyReferred.TryAdd(assembly, res);
        return res;
    }

    /// <summary>
    /// 获取引用了<typeparamref name="TType"/>的程序集
    /// </summary>
    /// <param name="dependencyContext">依赖上下文,null则使用默认</param>
    /// <returns></returns>
    public static List<Assembly> GetReferredAssemblies<TType>(
        DependencyContext? dependencyContext = null
    )
    {
        return GetReferredAssemblies(typeof(TType).Assembly, dependencyContext);
    }

    /// <summary>
    /// 获取引用了<param name="type"></param>的程序集
    /// </summary>
    /// <param name="dependencyContext">依赖上下文,null则使用默认</param>
    /// <returns></returns>
    public static List<Assembly> GetReferredAssemblies(
        Type type,
        DependencyContext? dependencyContext = null
    )
    {
        return GetReferredAssemblies(type.Assembly, dependencyContext);
    }

    /// <summary>
    /// 获取所有的子类,不包括接口和抽象类,包含泛型定义
    /// </summary>
    /// <param name="baseType">基类,可以是泛型定义</param>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static List<TypeInfo> GetFinalSubTypes(Type baseType, Assembly assembly)
    {
        return
        [
            .. assembly.DefinedTypes.Where(r =>
                !r.IsAbstract
                && r.IsClass
                && (r.IsSubTypeOrEqualsOf(baseType) || r.IsSubTypeOfGenericType(baseType))
            ),
        ];
    }

    /// <summary>
    /// 获取所有的子类和自身,不包括接口和抽象类,包含泛型定义
    /// </summary>
    /// <param name="baseType">基类,可以是泛型定义</param>
    /// <param name="dependencyContext"></param>
    /// <returns></returns>
    public static List<TypeInfo> GetFinalSubTypes(
        Type baseType,
        DependencyContext? dependencyContext = null
    )
    {
        List<TypeInfo> types = [];
        foreach (var item in GetReferredAssemblies(baseType, dependencyContext))
        {
            types.AddRange(GetFinalSubTypes(baseType, item));
        }

        types.AddRange(GetFinalSubTypes(baseType, baseType.Assembly));
        return types;
    }

    /// <summary>
    /// 获取所有的子类和自身,不包括接口和抽象类,包含泛型定义
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static List<TypeInfo> GetFinalSubTypes<TBaseType>(Assembly assembly)
    {
        return GetFinalSubTypes(typeof(TBaseType), assembly);
    }

    /// <summary>
    /// 获取所有的子类和自身,不包括接口和抽象类,包含泛型定义
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    /// <param name="dependencyContext"></param>
    /// <returns></returns>
    public static List<TypeInfo> GetFinalSubTypes<TBaseType>(
        DependencyContext? dependencyContext = null
    )
    {
        return GetFinalSubTypes(typeof(TBaseType), dependencyContext);
    }

    /// <summary>
    /// 获取所有的子类和自身,包括接口和抽象类,包含泛型定义
    /// </summary>
    /// <param name="baseType">基类,可以是泛型定义</param>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static List<TypeInfo> GetSubTypes(Type baseType, Assembly assembly)
    {
        return
        [
            .. assembly.DefinedTypes.Where(r =>
                r.IsSubTypeOrEqualsOf(baseType) || r.IsSubTypeOfGenericType(baseType)
            ),
        ];
    }

    /// <summary>
    /// 获取所有的子类和自身,包括接口和抽象类,包含泛型定义
    /// </summary>
    /// <param name="baseType">基类,可以是泛型定义</param>
    /// <param name="dependencyContext"></param>
    /// <returns></returns>
    public static List<TypeInfo> GetSubTypes(
        Type baseType,
        DependencyContext? dependencyContext = null
    )
    {
        var types = new List<TypeInfo>();
        foreach (var item in GetReferredAssemblies(baseType, dependencyContext))
            types.AddRange(GetSubTypes(baseType, item));

        types.AddRange(GetSubTypes(baseType, baseType.Assembly));
        return types;
    }

    /// <summary>
    /// 获取所有的子类和自身,包括接口和抽象类,包含泛型定义
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static List<TypeInfo> GetSubTypes<TBaseType>(Assembly assembly)
    {
        return GetSubTypes(typeof(TBaseType), assembly);
    }

    /// <summary>
    /// 获取所有的子类和自身,包括接口和抽象类,包含泛型定义
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    /// <param name="dependencyContext"></param>
    /// <returns></returns>
    public static List<TypeInfo> GetSubTypes<TBaseType>(DependencyContext? dependencyContext = null)
    {
        return GetSubTypes(typeof(TBaseType), dependencyContext);
    }

    /// <summary>
    /// 根据特性获取类和特性值,不支持多特性Multiple
    /// </summary>
    /// <param name="baseType"></param>
    /// <param name="assembly"></param>
    /// <param name="inherit"></param>
    /// <returns></returns>
    public static IDictionary<TypeInfo, Attribute> GetTypesAndAttribute(
        Type baseType,
        Assembly assembly,
        bool inherit = true
    )
    {
        Dictionary<TypeInfo, Attribute> dic = [];

        foreach (var item in assembly.DefinedTypes)
        {
            var attr = item.GetCustomAttribute(baseType, inherit);
            if (attr is null)
                continue;

            dic.Add(item, attr);
        }

        return dic;
    }

    /// <summary>
    /// 根据特性获取类和特性值,不支持多特性Multiple
    /// </summary>
    /// <param name="baseType">基类,可以是泛型定义</param>
    /// <param name="dependencyContext"></param>
    /// <param name="inherit"></param>
    /// <returns></returns>
    public static IDictionary<TypeInfo, Attribute> GetTypesAndAttribute(
        Type baseType,
        DependencyContext? dependencyContext = null,
        bool inherit = true
    )
    {
        Dictionary<TypeInfo, Attribute> dic = [];
        foreach (var item in GetReferredAssemblies(baseType, dependencyContext))
        {
            dic.Merge(GetTypesAndAttribute(baseType, item, inherit));
        }

        dic.Merge(GetTypesAndAttribute(baseType, baseType.Assembly, inherit));

        return dic;
    }

    /// <summary>
    /// 根据特性获取类和特性值,不支持多特性Multiple
    /// </summary>
    /// <param name="assembly"></param>
    /// <param name="inherit"></param>
    /// <returns></returns>
    public static IDictionary<TypeInfo, TAttribute> GetTypesAndAttribute<TAttribute>(
        Assembly assembly,
        bool inherit = true
    )
        where TAttribute : Attribute
    {
        Dictionary<TypeInfo, TAttribute> dic = [];

        foreach (var item in assembly.DefinedTypes)
        {
            var attr = item.GetCustomAttribute<TAttribute>(inherit);
            if (attr is null)
                continue;

            dic.Add(item, attr);
        }

        return dic;
    }

    /// <summary>
    /// 根据特性获取类和特性值,不支持多特性Multiple
    /// </summary>
    /// <typeparam name="TAttribute"></typeparam>
    /// <param name="dependencyContext"></param>
    /// <param name="inherit"></param>
    /// <returns></returns>
    public static IDictionary<TypeInfo, TAttribute> GetTypesAndAttribute<TAttribute>(
        DependencyContext? dependencyContext = null,
        bool inherit = true
    )
        where TAttribute : Attribute
    {
        Dictionary<TypeInfo, TAttribute> dic = [];
        foreach (var item in GetReferredAssemblies<TAttribute>(dependencyContext))
        {
            dic.Merge(GetTypesAndAttribute<TAttribute>(item, inherit));
        }

        dic.Merge(GetTypesAndAttribute<TAttribute>(typeof(TAttribute).Assembly, inherit));

        return dic;
    }

    /// <summary>
    /// 根据特性获取类和特性值,不支持多特性Multiple
    /// </summary>
    /// <param name="baseType"></param>
    /// <param name="assembly"></param>
    /// <param name="inherit"></param>
    /// <returns></returns>
    public static IDictionary<TypeInfo, IEnumerable<object>> GetTypesByAttributes(
        Type baseType,
        Assembly assembly,
        bool inherit = true
    )
    {
        Dictionary<TypeInfo, IEnumerable<object>> dic = [];

        foreach (var item in assembly.DefinedTypes)
        {
            var attrs = item.GetCustomAttributes(baseType, inherit);
            if (attrs is null || attrs.Length == 0)
                continue;

            dic.Add(item, attrs);
        }

        return dic;
    }

    /// <summary>
    /// 根据特性获取类和特性值,不支持多特性Multiple
    /// </summary>
    /// <param name="baseType"></param>
    /// <param name="dependencyContext"></param>
    /// <param name="inherit"></param>
    /// <returns></returns>
    public static IDictionary<TypeInfo, IEnumerable<object>> GetTypesByAttributes(
        Type baseType,
        DependencyContext? dependencyContext = null,
        bool inherit = true
    )
    {
        Dictionary<TypeInfo, IEnumerable<object>> dic = [];
        foreach (var item in GetReferredAssemblies(baseType, dependencyContext))
        {
            dic.Merge(GetTypesByAttributes(baseType, item, inherit));
        }

        dic.Merge(GetTypesByAttributes(baseType, baseType.Assembly, inherit));

        return dic;
    }

    /// <summary>
    /// 根据特性获取类和特性值,不支持多特性Multiple
    /// </summary>
    /// <param name="assembly"></param>
    /// <param name="inherit"></param>
    /// <returns></returns>
    public static IDictionary<TypeInfo, IEnumerable<TAttribute>> GetTypesByAttributes<TAttribute>(
        Assembly assembly,
        bool inherit = true
    )
        where TAttribute : Attribute
    {
        Dictionary<TypeInfo, IEnumerable<TAttribute>> dic = [];

        foreach (var item in assembly.DefinedTypes)
        {
            var attrs = item.GetCustomAttributes<TAttribute>(inherit).ToList();
            if (attrs.Count == 0)
                continue;

            dic.Add(item, attrs);
        }

        return dic;
    }

    /// <summary>
    /// 根据特性获取类和特性值,不支持多特性Multiple
    /// </summary>
    /// <typeparam name="TAttribute"></typeparam>
    /// <param name="dependencyContext"></param>
    /// <param name="inherit"></param>
    /// <returns></returns>
    public static IDictionary<TypeInfo, IEnumerable<TAttribute>> GetTypesByAttributes<TAttribute>(
        DependencyContext? dependencyContext = null,
        bool inherit = true
    )
        where TAttribute : Attribute
    {
        Dictionary<TypeInfo, IEnumerable<TAttribute>> dic = [];
        foreach (var item in GetReferredAssemblies<TAttribute>(dependencyContext))
        {
            dic.Merge(GetTypesByAttributes<TAttribute>(item, inherit));
        }

        dic.Merge(GetTypesByAttributes<TAttribute>(typeof(TAttribute).Assembly, inherit));

        return dic;
    }

    /// <summary>
    /// 判断参数是否带问号
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public static bool IsParameterNullable(ParameterInfo parameter)
    {
        var context = new NullabilityInfoContext();
        var nullabilityInfo = context.Create(parameter);

        return nullabilityInfo.ReadState == NullabilityState.Nullable;
    }

    #region private

    /// <summary>
    /// 缓存程序集被引用数据
    /// </summary>
    private static readonly ConcurrentDictionary<Assembly, List<Assembly>> CacheAssemblyReferred =
        new();

    /// <summary>
    /// 加载所有的依赖
    /// </summary>
    /// <param name="allLibs">应用包含的所有程序集</param>
    /// <param name="key">当前计算的程序集name</param>
    /// <param name="handled">当前计算的程序集,已经处理过的依赖程序集名称</param>
    /// <param name="current">递归正在处理的程序集名称</param>
    /// <param name="allDependencies">所有的依赖数据</param>
    private static void LoadAllDependency(
        IEnumerable<RuntimeLibrary> allLibs,
        string key,
        HashSet<string> handled,
        RuntimeLibrary current,
        Dictionary<string, HashSet<string>> allDependencies
    )
    {
        if (current.Dependencies.Count == 0)
            return;
        if (handled.Contains(current.Name))
            return;
        handled.Add(current.Name);
        var runtimeLibraries = allLibs.ToList();
        foreach (var item in current.Dependencies)
        {
            allDependencies[key].Add(item.Name);

            var next = runtimeLibraries.FirstOrDefault(r => r.Name == item.Name);
            if (next is null || next.Dependencies.Count == 0)
                continue;
            LoadAllDependency(runtimeLibraries, key, handled, next, allDependencies);
        }
    }

    #endregion
}

internal static partial class InnerExtensions
{
    /// <summary>
    /// 合并两个字典，并覆盖相同键名的值
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="to"></param>
    /// <param name="from"></param>
    public static void Merge<TKey, TValue>(
        this IDictionary<TKey, TValue> to,
        IDictionary<TKey, TValue>? from
    )
    {
        ArgumentNullException.ThrowIfNull(to);
        if (from is null)
            return;
        foreach (var kv in from)
        {
            if (to.ContainsKey(kv.Key))
            {
                to[kv.Key] = kv.Value;
            }
            else
            {
                to.Add(kv.Key, kv.Value);
            }
        }
    }

    /// <summary>
    /// 是否为类型<paramref name="parentType"/>的子类或自身
    /// </summary>
    /// <param name="type"></param>
    /// <param name="parentType">父类</param>
    /// <returns></returns>
    public static bool IsSubTypeOrEqualsOf(this Type type, Type parentType)
    {
        return parentType.IsAssignableFrom(type);
    }

    /// <summary>
    /// 判断给定的类型是否继承自<paramref name="genericType"/>泛型类型,
    /// <para>
    /// e.g.: typeof(Child&lt;&gt;).IsSubTypeOfGenericType(typeof(IParent&lt;&gt;));  result->true
    /// </para>
    /// <para>
    /// e.g.: typeof(Child&lt;int&gt;).IsSubTypeOfGenericType(typeof(IParent&lt;&gt;));  result->true
    /// </para>
    /// </summary>
    /// <param name="childType">子类型</param>
    /// <param name="genericType">泛型父级,例: typeof(IParent&lt;&gt;)</param>
    /// <returns></returns>
    public static bool IsSubTypeOfGenericType(this Type childType, Type genericType)
    {
        if (childType == genericType)
            return false;
        if (!genericType.IsGenericTypeDefinition)
            return false;
        var interfaceTypes = childType.GetTypeInfo().ImplementedInterfaces;

        foreach (var it in interfaceTypes)
        {
            if (it.IsGenericType && it.GetGenericTypeDefinition() == genericType)
                return true;
        }

        if (childType.IsGenericType && childType.GetGenericTypeDefinition() == genericType)
            return true;

        var baseType = childType.BaseType;
        if (baseType is null)
            return false;

        return IsSubTypeOfGenericType(baseType, genericType);
    }

    /// <summary>
    /// 获取字典值,没有则返回默认值
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="dic"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static TValue? GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key)
    {
        if (key is null)
            return default;
        return dic.TryGetValue(key, out var value) ? value : default;
    }
}
