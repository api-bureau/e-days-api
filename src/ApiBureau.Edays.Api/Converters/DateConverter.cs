using System.Text.Json.Serialization;

namespace ApiBureau.Edays.Api.Converters;

// This doesn't support nulls
public class DateConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => DateTime.Parse(reader.GetString() ?? "Conversion failed");

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) => throw new NotImplementedException();
}
