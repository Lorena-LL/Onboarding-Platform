using OnboardingAPI.Models.Enums;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace OnboardingAPI.Models.Converters
{
    public class RoleJsonConverter : JsonConverter<Role>
    {
        public override Role Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            string? value = reader.GetString();

            if (string.IsNullOrWhiteSpace(value))
                throw new JsonException("Role value cannot be empty.");

            string normalized = value.Replace(" ", "")
                                      .Replace("-", "")
                                      .Replace("_", "");

            foreach (Role role in Enum.GetValues<Role>())
            {
                if (string.Equals(role.ToString(), normalized, StringComparison.OrdinalIgnoreCase))
                {
                    return role;
                }
            }

            throw new JsonException(
                $"Invalid role value: '{value}'. Valid values: {string.Join(", ", Enum.GetNames<Role>())}");
        }

        public override void Write(
            Utf8JsonWriter writer,
            Role value,
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