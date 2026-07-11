using OnboardingAPI.Models.Converters;
using System.Text.Json.Serialization;

namespace OnboardingAPI.Models.Enums
{
    [JsonConverter(typeof(SpaceSeparatedEnumConverter<Role>))]
    public enum Role
    {
        SoftwareEngineer,
        SecurityEngineer,
        ProductManager,
        FrontendDeveloper,
        HumanResources,
        DirectorOfSales,
        AccountExecutive,
        ProductMarketingManager,
        FinancialAnalyst,
        ChiefFinancialOfficer
    }
}