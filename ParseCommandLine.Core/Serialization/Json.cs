using System.Text.Json;
using System.Text.Json.Serialization;

namespace ParseCommandLine.Core.Serialization;

public static class Json
{
    private static readonly JsonSerializerOptions Options = new()
    {
        DictionaryKeyPolicy  = JsonNamingPolicy.CamelCase,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters =
        {
            new JsonStringEnumConverter()
        }
    };
    
    public static T? Deserialize<T>(string value)
    {
        return JsonSerializer.Deserialize<T>(
            value,
            Options);
    }
}
