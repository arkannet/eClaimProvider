using eClaimProvider.Shared.Settings;
using System.Threading.Tasks;
using eClaimProvider.Shared.Wrapper;

namespace eClaimProvider.Shared.Managers
{
    public interface IPreferenceManager
    {
        Task SetPreference(IPreference preference);

        Task<IPreference> GetPreference();

        Task<IResult> ChangeLanguageAsync(string languageCode);
    }
}