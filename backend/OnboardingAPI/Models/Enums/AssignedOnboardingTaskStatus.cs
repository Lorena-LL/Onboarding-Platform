using OnboardingAPI.Models.Converters;
using System.Text.Json.Serialization;

namespace OnboardingAPI.Models.Enums
{
    [JsonConverter(typeof(SpaceSeparatedEnumConverter<AssignedOnboardingTaskStatus>))]
    public enum AssignedOnboardingTaskStatus
    {
        Active,
        Completed
    }
}