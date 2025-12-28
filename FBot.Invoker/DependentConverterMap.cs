using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace FBot.Invoker;

public class DependentConverterMap
    : IDictionary<Type, List<Type>>,
        IReadOnlyDictionary<Type, List<Type>>
{
    private readonly Dictionary<Type, List<Type>> _innerDictionary = [];

    public List<Type> this[Type key]
    {
        get => _innerDictionary[key];
        set => _innerDictionary[key] = value;
    }

    public ICollection<Type> Keys => _innerDictionary.Keys;

    public ICollection<List<Type>> Values => _innerDictionary.Values;

    IEnumerable<Type> IReadOnlyDictionary<Type, List<Type>>.Keys => Keys;

    IEnumerable<List<Type>> IReadOnlyDictionary<Type, List<Type>>.Values => Values;

    public int Count => _innerDictionary.Count;

    public bool IsReadOnly => false;

    public void Add<T, TDependent>()
        where TDependent : IDependent => Add(typeof(T), typeof(TDependent));

    public void Add(Type key, Type value)
    {
        if (!_innerDictionary.TryGetValue(key, out var list))
        {
            list = [];
            _innerDictionary.Add(key, list);
        }
        if (!typeof(IDependent).IsAssignableFrom(value))
        {
            throw new NotSupportedException(
                $"Type {value} does not implement {nameof(IDependent)}"
            );
        }
        list.Add(value);
    }

    public void Add(Type key, List<Type> value)
    {
        Add(key, (IEnumerable<Type>)value);
    }

    public void Add(Type key, IEnumerable<Type> value)
    {
        if (!_innerDictionary.TryGetValue(key, out var list))
        {
            list = [];
            _innerDictionary.Add(key, list);
        }
        foreach (var item in value)
        {
            if (!typeof(IDependent).IsAssignableFrom(item))
            {
                throw new NotSupportedException(
                    $"Type {item} does not implement {nameof(IDependent)}"
                );
            }
        }

        list.AddRange(value);
    }

    void ICollection<KeyValuePair<Type, List<Type>>>.Add(KeyValuePair<Type, List<Type>> item)
    {
        Add(item.Key, item.Value);
    }

    public void Clear()
    {
        _innerDictionary.Clear();
    }

    public bool Contains(KeyValuePair<Type, List<Type>> item)
    {
        return _innerDictionary.Contains(item);
    }

    public bool ContainsKey(Type key)
    {
        return _innerDictionary.ContainsKey(key);
    }

    void ICollection<KeyValuePair<Type, List<Type>>>.CopyTo(
        KeyValuePair<Type, List<Type>>[] array,
        int arrayIndex
    )
    {
        ((ICollection<KeyValuePair<Type, List<Type>>>)_innerDictionary).CopyTo(array, arrayIndex);
    }

    public IEnumerator<KeyValuePair<Type, List<Type>>> GetEnumerator()
    {
        return _innerDictionary.GetEnumerator();
    }

    public bool Remove(Type key)
    {
        return _innerDictionary.Remove(key);
    }

    bool ICollection<KeyValuePair<Type, List<Type>>>.Remove(KeyValuePair<Type, List<Type>> item)
    {
        return ((ICollection<KeyValuePair<Type, List<Type>>>)_innerDictionary).Remove(item);
    }

    public bool TryGetValue(Type key, [MaybeNullWhen(false)] out List<Type> value)
    {
        return _innerDictionary.TryGetValue(key, out value);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
