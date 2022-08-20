using System.Text.Json;
using System.Text.Json.Serialization;

namespace ParseCommandLine.Core.Serialization;

public static class Json
{
    public static T? Deserialize<T>(string value)
    {
        return JsonSerializer.Deserialize<T>(
            value,
            new JsonSerializerOptions
            {
                DictionaryKeyPolicy  = JsonNamingPolicy.CamelCase,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters =
                {
                    new JsonStringEnumConverter()
                }
            });
    }
}
