using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PipServices.Commons.Config;
using PipServices.Commons.Data;
using PipServices.Commons.Refer;
using PipServices.Net.Direct;
using PipServices.UsersPreferences.Logic;

namespace PipServices.Users.Preferences.Client.Version1
{
    public class UsersPreferencesDirectClientV1 : DirectClient<dynamic>, IUsersPreferencesClientV1
    {
        public UsersPreferencesDirectClientV1() : base()
        {
            this._dependencyResolver.Put("controller", new Descriptor("pip-services-users-preferences", "controller", "*", "*", "*"));
        }

        public async Task<DataPage<UserPreferencesV1>> GetUsersPreferencesAsync(string correlationId, FilterParams filter, PagingParams paging) {
            return await this._controller.GetUsersPreferencesAsync(correlationId, filter, paging);
        }

        public async Task<UserPreferencesV1> GetUserPreferencesByIdAsync(string correlationId, string userPreferencesId) {
            return await this._controller.GetUserPreferencesByIdAsync(correlationId, userPreferencesId);
        }

        public async Task<UserPreferencesV1> SetUserPreferencesAsync(string correlationId, dynamic userPreferences) {
            return await this._controller.SetUserPreferencesAsync(correlationId, userPreferences);
        }

        public async Task<UserPreferencesV1> ClearUserPreferencesAsync(string correlationId, dynamic userPreferences) {
            return await this._controller.ClearUserPreferencesAsync(correlationId, userPreferences);
        }
    }
}
