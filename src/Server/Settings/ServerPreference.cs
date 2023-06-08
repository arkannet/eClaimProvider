using System.Linq;
using eClaimProvider.Shared.Constants.Localization;
using eClaimProvider.Shared.Settings;

namespace eClaimProvider.Server.Settings
{
    public record ServerPreference : IPreference
    {
        public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US";

        //TODO - add server preferences
    }
}