using Microsoft.Extensions.Logging.Console;
using PipServices.Commons.Refer;
using PipServices.Users.Preferences.Client.Version1;
using PipServices.UsersPreferences.Logic;
using PipServices.UsersPreferences.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PipServices.Users.Preferences.Client.Version1
{
    public class UsersPreferencesDirectClientTest
    {
        private UsersPreferencesDirectClientV1 _client;
        private UsersPreferencesCilentFixture _fixture;

        public UsersPreferencesDirectClientTest()
        {
            var persistence = new UsersPreferencesMemoryPersistence();
            var controller = new UsersPreferencesController();

            References references = References.FromTuples(
                new Descriptor("pip-services-users-preferences", "persistence", "memory", "default", "1.0"), persistence,
                new Descriptor("pip-services-users-preferences", "controller", "default", "default", "1.0"), controller

            );
            controller.SetReferences(references);

            _client = new UsersPreferencesDirectClientV1();
            _client.SetReferences(references);

            _fixture = new UsersPreferencesCilentFixture(_client);

            _client.OpenAsync(null);
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
