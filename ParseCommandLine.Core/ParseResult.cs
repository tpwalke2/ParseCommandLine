using System.ComponentModel;
using ParseCommandLine.Core.Extensions;
using ParseCommandLine.Core.Serialization;

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
        try
        {
            return Json.Deserialize<T>(_values.TryGetOrDefault(key, "")!);
        }
        catch (Exception)
        {
            // fallback to type conversion
            var result = TypeDescriptor
                         .GetConverter(typeof(T))
                         .ConvertFrom(_values.TryGetOrDefault(key, "")!);

            return result == null
                ? default
                : (T?)result;
        }
    }
}
