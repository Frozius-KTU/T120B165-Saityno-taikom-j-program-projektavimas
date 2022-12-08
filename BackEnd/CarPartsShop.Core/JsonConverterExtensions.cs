using System.Text.Json.Serialization;
using CarPartsShop.Core.Converters;

namespace CarPartsShop.Core.Extensions;

public static class JsonConverterExtensions
{
    private static IList<JsonConverter> List => new List<JsonConverter>
    {
        new DateOnlyConverter(),
        new TimeOnlyConverter(),
    };

    public static void AddConverters(this IList<JsonConverter> list)
    {
        foreach (var converter in List)
        {
            list.Add(converter);
        }
    }
}
