using PipServices.Commons.Data;

using System.Threading.Tasks;

namespace PipServices.Users.Preferences.Client.Version1
{
    public interface IUsersPreferencesClientV1
    {
        Task<DataPage<dynamic>> GetUsersPreferencesAsync(string correlationId, FilterParams filter, PagingParams paging);
        Task<dynamic> GetUserPreferencesByIdAsync(string correlationId, string userPreferencesId);
        Task<dynamic> SetUserPreferencesAsync(string correlationId, dynamic userPreferences);
        Task<dynamic> ClearUserPreferencesAsync(string correlationId, dynamic userPreferences);
    }
}
