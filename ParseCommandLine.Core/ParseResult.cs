using System.ComponentModel;
using ParseCommandLine.Core.Extensions;

namespace ParseCommandLine.Core;

public class ParseResult
{
    private readonly IDictionary<string, string> _values;

    public ParseResult(IEnumerable<KeyValuePair<string, string>> values)
    {
        _values = new Dictionary<string, string>(values, StringComparer.OrdinalIgnoreCase);
    }

    public int Count => _values.Count;
    
    public T? Arg<T>(string key)
    {
        var result = TypeDescriptor
                     .GetConverter(typeof(T))
                     .ConvertFrom(_values.TryGetOrDefault(key, "")!);

        return result == null
            ? default
            : (T?)result;
    }
}
