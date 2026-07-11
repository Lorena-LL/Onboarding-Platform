using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace OnboardingAPI.Models.Converters
{
    public class SpaceSeparatedEnumConverter<T> : JsonConverter<T> where T : struct, Enum
    {
        public override T Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            string? value = reader.GetString();

            if (string.IsNullOrWhiteSpace(value))
                throw new JsonException($"{typeof(T).Name} value cannot be empty.");

            string normalized = value.Replace(" ", "")
                                     .Replace("-", "")
                                     .Replace("_", "");

            foreach (T enumValue in Enum.GetValues<T>())
            {
                if (string.Equals(enumValue.ToString(), normalized, StringComparison.OrdinalIgnoreCase))
                {
                    return enumValue;
                }
            }

            throw new JsonException(
                $"Invalid {typeof(T).Name} value: '{value}'. Valid values: {string.Join(", ", Enum.GetNames<T>())}");
        }

        public override void Write(
            Utf8JsonWriter writer,
            T value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(InsertSpacesBeforeCapitals(value.ToString()));
        }

        private static string InsertSpacesBeforeCapitals(string input)
        {
            return Regex.Replace(input, "(?<!^)([A-Z])", " $1");
        }
    }
}