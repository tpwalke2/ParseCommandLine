using System.ComponentModel;
using ParseCommandLine.Core.Extensions;
using ParseCommandLine.Core.Serialization;

namespace ParseCommandLine.Core;

public class ParseResult(IEnumerable<KeyValuePair<string, string>> values)
{
    private readonly Dictionary<string, string> _values = new(values, StringComparer.OrdinalIgnoreCase);

    public int Count => _values.Count;

    public T? Arg<T>(string key)
    {
        T? ConvertType(Type type) => (T?)TypeDescriptor
                                         .GetConverter(type)
                                         .ConvertFrom(_values.TryGetOrDefault(key, "")!);

        var t = typeof(T);

        if (t.IsPrimitive || t == typeof(string))
        {
            return ConvertType(t);
        }

        try
        {
            return Json.Deserialize<T>(_values.TryGetOrDefault(key, "")!);
        }
        catch (Exception)
        {
            // fallback to type conversion
            return ConvertType(t) ?? default;
        }
    }
}
