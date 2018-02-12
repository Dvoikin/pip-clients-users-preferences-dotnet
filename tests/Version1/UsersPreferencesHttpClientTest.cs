using Microsoft.Extensions.Logging.Console;
using PipServices.Commons.Refer;
using PipServices.Users.Preferences.Client.Version1;
using PipServices.UsersPreferences.Logic;
using PipServices.UsersPreferences.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

using PipServices.Commons.Config;

namespace PipServices.Users.Preferences.Client.Version1
{
    public class UsersPreferencesHttpClientTest
    {
        private static readonly ConfigParams RestConfig = ConfigParams.FromTuples(
            "connection.protocol", "http",
            "connection.host", "localhost",
            "connection.port", 8080
            );

        private UsersPreferencesHttpClientV1 _client;
        private UsersPreferencesCilentFixture _fixture;

        public UsersPreferencesHttpClientTest()
        {
            _client = new UsersPreferencesHttpClientV1();
            _client.Configure(RestConfig);

            _fixture = new UsersPreferencesCilentFixture(_client);

            var clientTask = _client.OpenAsync(null);
            clientTask.Wait();
        }

        [Fact]
        public void TestCrudOperations()
        {
            var task = _fixture.TestCrudOperationsAsync();
            task.Wait();
        }

        [Fact]
        public void TestGetByFilterAsync()
        {
            var task = _fixture.TestGetByFilterAsync();
            task.Wait();
        }

        public void Dispose()
        {
            var task = _client.CloseAsync(null);
            task.Wait();
        }

    }
}
