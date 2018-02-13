using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PipServices.Commons.Config;
using PipServices.Commons.Data;
using PipServices.Commons.Refer;
using PipServices.Net.Direct;
using PipServices.UsersPreferences.Logic;

using dataType = PipServices.UsersPreferences.Data.Version1.UserPreferencesV1;

namespace PipServices.Users.Preferences.Client.Version1
{
    public class UsersPreferencesDirectClientV1 : DirectClient<UsersPreferencesController>, IUsersPreferencesClientV1<dataType>
    {
        public UsersPreferencesDirectClientV1() : base()
        {
            this._dependencyResolver.Put("controller", new Descriptor("pip-services-users-preferences", "controller", "*", "*", "*"));
        }

        public async Task<DataPage<dataType>> GetUsersPreferencesAsync(string correlationId, FilterParams filter, PagingParams paging) {
            return await this._controller.GetUsersPreferencesAsync(correlationId, filter, paging);
        }

        public async Task<dataType> GetUserPreferencesByIdAsync(string correlationId, string userPreferencesId) {
            return await this._controller.GetUserPreferencesByIdAsync(correlationId, userPreferencesId);
        }

        public async Task<dataType> SetUserPreferencesAsync(string correlationId, dataType userPreferences) {
            return await this._controller.SetUserPreferencesAsync(correlationId, userPreferences);
        }

        public async Task<dataType> ClearUserPreferencesAsync(string correlationId, dataType userPreferences) {
            return await this._controller.ClearUserPreferencesAsync(correlationId, userPreferences);
        }

        public async Task<dataType> ClearUsersPreferencesAsync(string correlationId)
        {
            return await this._controller.ClearUsersPreferencesAsync(correlationId);
        }
    }
}
