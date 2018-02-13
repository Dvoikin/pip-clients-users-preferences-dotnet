using PipServices.Commons.Data;

using System.Threading.Tasks;


namespace PipServices.Users.Preferences.Client.Version1
{
    public interface IUsersPreferencesClientV1<T>
    {
        Task<DataPage<T>> GetUsersPreferencesAsync(string correlationId, FilterParams filter, PagingParams paging);
        Task<T> GetUserPreferencesByIdAsync(string correlationId, string userPreferencesId);
        Task<T> SetUserPreferencesAsync(string correlationId, T userPreferences);
        Task<T> ClearUserPreferencesAsync(string correlationId, T userPreferences);
        Task<T> ClearUsersPreferencesAsync(string correlationId);
    }
}
