using OnboardingAPI.Models.Converters;
using System.Text.Json.Serialization;

namespace OnboardingAPI.Models.Enums
{
    [JsonConverter(typeof(SpaceSeparatedEnumConverter<OnboardingTaskCategory>))]
    public enum OnboardingTaskCategory
    {
        WorkplaceAndScheduling,
        CommunicationTools,
        Technical,
        CompanyBenefits
    }
}