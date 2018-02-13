using System.Threading.Tasks;

using PipServices.Commons.Data;
using PipServices.Net.Rest;

namespace PipServices.Users.Preferences.Client.Version1
{
    public class UsersPreferencesHttpClientV1 : CommandableHttpClient, IUsersPreferencesClientV1<UserPreferencesV1>
    {
        public UsersPreferencesHttpClientV1()
            : base("users_preferences")
        {
        }

        public Task<DataPage<UserPreferencesV1>> GetUsersPreferencesAsync(string correlationId, FilterParams filter, PagingParams paging) {
            using (var timing = Instrument(correlationId))
            {
                return CallCommand<DataPage<UserPreferencesV1>>("get_user_preferences", correlationId, new
                {
                    correlation_id = correlationId,
                    filter = filter ?? new FilterParams(),
                    paging = paging ?? new PagingParams()
                });
            }
        }

        public Task<UserPreferencesV1> GetUserPreferencesByIdAsync(string correlationId, string userPreferencesId) {
            using (var timing = Instrument(correlationId))
            {
                return CallCommand<UserPreferencesV1>("get_user_preferences_by_id", correlationId, new
                {
                    correlation_id = correlationId,
                    user_preferences_id = userPreferencesId
                });
            }
        }

        public Task<UserPreferencesV1> SetUserPreferencesAsync(string correlationId, UserPreferencesV1 userPreferences) {
            using (var timing = Instrument(correlationId))
            {
                return CallCommand<UserPreferencesV1>("set_user_preferences", correlationId, new
                {
                    correlation_id = correlationId,
                    user_preferences = userPreferences
                });
            }
        }

        public Task<UserPreferencesV1> ClearUserPreferencesAsync(string correlationId, UserPreferencesV1 userPreferences) {
            using (var timing = Instrument(correlationId))
            {
                return CallCommand<UserPreferencesV1>("clear_user_preferences", correlationId, new
                {
                    correlation_id = correlationId,
                    user_preferences = userPreferences
                });
            }
        }

        public Task<UserPreferencesV1> ClearUsersPreferencesAsync(string correlationId)
        {
            using (var timing = Instrument(correlationId))
            {
                return CallCommand<UserPreferencesV1>("clear_users_preferences", correlationId, new
                {
                    correlation_id = correlationId
                });
            }
        }
    }
}
