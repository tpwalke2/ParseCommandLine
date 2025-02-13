namespace ParseCommandLine.Core.Extensions;

public static class DictionaryExtensions
{
    public static TValue? TryGetOrDefault<TKey, TValue>(
        this IDictionary<TKey, TValue> dictionary,
        TKey key,
        TValue? defaultValue = default)
    {
        if (Equals(key, null)) return defaultValue;

        return dictionary.TryGetValue(key, out var result) ? result : defaultValue;
    }
}
