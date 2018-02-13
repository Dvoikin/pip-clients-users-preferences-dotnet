using System;
using Xunit;

using PipServices.Commons.Config;
using PipServices.Commons.Data;

using dataType = PipServices.Users.Preferences.Client.Version1.UserPreferencesV1;

namespace PipServices.Users.Preferences.Client.Version1
{
    public class UsersPreferencesHttpClientTest : IDisposable
    {

        private static dynamic USER_PREFERENCES1 = CreateUserPreferences("1", "1", "green", "en", "mail@mail");
        private static dynamic USER_PREFERENCES2 = CreateUserPreferences("2", "2", "blue", "ru", "mail2@mail");
        private static dynamic USER_PREFERENCES3 = CreateUserPreferences("3", "3", "blue", "ru", "mail3@mail");

        private static readonly ConfigParams RestConfig = ConfigParams.FromTuples(
            "connection.protocol", "http",
            "connection.host", "localhost",
            "connection.port", 8080
            );

        private UsersPreferencesHttpClientV1 _client;
        //private UsersPreferencesCilentFixture _fixture;

        public UsersPreferencesHttpClientTest()
        {
            _client = new UsersPreferencesHttpClientV1();
            _client.Configure(RestConfig);

            //_fixture = new UsersPreferencesCilentFixture(_client);

            var clientTask = _client.OpenAsync(null);
            clientTask.Wait();
        }

        private static dataType CreateUserPreferences(string id, string userId, string theme, string language, string email)
        {
            var userPreferences = new dataType
            {
                Id = userId,
                UserId = userId,
                Theme = theme,
                Language = language,
                PreferredEmail = email,
                TimeZone = "UTC+3"
            };

            return userPreferences;
        }

        [Fact]
        public async void TestCrudOperations()
        {
            await _client.ClearUsersPreferencesAsync(null);
            // Create one user preferences
            dataType userPreferences1 = await _client.SetUserPreferencesAsync(null, USER_PREFERENCES1);

            Assert.NotNull(userPreferences1);
            Assert.Equal(USER_PREFERENCES1.Id, userPreferences1.Id);
            Assert.Equal(USER_PREFERENCES1.UserId, userPreferences1.UserId);

            // Create another userPreferences
            dataType userPreferences2 = await _client.SetUserPreferencesAsync(null, USER_PREFERENCES2);

            Assert.NotNull(userPreferences2);
            Assert.Equal(USER_PREFERENCES2.Id, userPreferences2.Id);
            Assert.Equal(USER_PREFERENCES2.UserId, userPreferences2.UserId);

            // Create another userPreferences
            dataType userPreferences3 = await _client.SetUserPreferencesAsync(null, USER_PREFERENCES3);

            Assert.NotNull(userPreferences3);
            Assert.Equal(USER_PREFERENCES3.Id, userPreferences3.Id);
            Assert.Equal(USER_PREFERENCES3.UserId, userPreferences3.UserId);

            // Get all users preferences
            DataPage<dataType> page = await _client.GetUsersPreferencesAsync(null, null, null);
            Assert.NotNull(page);
            Assert.NotNull(page.Data);
            Assert.Equal(3, page.Data.Count);

            // Update the user Preferences
            userPreferences1.UserId = "3";
            dataType userPreferences = await _client.SetUserPreferencesAsync(
                null,
                userPreferences1
            );

            Assert.NotNull(userPreferences);
            Assert.Equal(userPreferences1.Id, userPreferences.Id);
            Assert.Equal("3", userPreferences.UserId);

            // Clear the user preferences
            userPreferences = await _client.ClearUserPreferencesAsync(null, userPreferences1);

            Assert.Null(userPreferences.Theme);
        }

        [Fact]
        public async void TestGetByFilterAsync()
        {
            await _client.ClearUsersPreferencesAsync(null);

            await _client.SetUserPreferencesAsync(null, USER_PREFERENCES1);
            await _client.SetUserPreferencesAsync(null, USER_PREFERENCES2);
            await _client.SetUserPreferencesAsync(null, USER_PREFERENCES3);

            // Get by id
            FilterParams filter = FilterParams.FromTuples("user_id", "1");
            DataPage<dataType> page = await _client.GetUsersPreferencesAsync(null, filter, null);
            Assert.Single(page.Data);

            // Get by theme
            filter = FilterParams.FromTuples("theme", "blue");
            page = await _client.GetUsersPreferencesAsync(null, filter, null);
            Assert.Equal(2, page.Data.Count);

            // Get by search
            filter = FilterParams.FromTuples("search", USER_PREFERENCES1.PreferredEmail);
            page = await _client.GetUsersPreferencesAsync(null, filter, null);
            Assert.Single(page.Data);
        }

        public void Dispose()
        {
            var task = _client.CloseAsync(null);
            task.Wait();
        }

    }
}
