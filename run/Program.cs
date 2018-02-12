using PipServices.Commons.Config;
using PipServices.Commons.Data;
using PipServices.Users.Preferences.Client.Version1;

using System;

namespace run
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var correlationId = "123";
                var config = ConfigParams.FromTuples(
                    "connection.type", "http",
                    "connection.host", "localhost",
                    "connection.port", 8080
                );

                var client = new UsersPreferencesHttpClientV1();
                client.Configure(config);
                client.OpenAsync(correlationId);

                var up = client.SetUserPreferencesAsync(correlationId, new UserPreferencesV1
                {
                    Id = "1",
                    UserId = "1",
                    Theme = "green",
                    Language = "en",
                    TimeZone = "UTC+3",
                    PreferredEmail = "mymail@mail.com"
                }).Result;
                
                var ups = client.GetUsersPreferencesAsync(correlationId, null, null).Result;

                if (ups != null)
                {
                    Console.WriteLine("Length: '{0}'", ups.Data.Count);
                }
                else
                {
                    Console.WriteLine("No users preferences were returned. Come up with your own...");
                }

                Console.WriteLine("Press ENTER to exit...");
                Console.ReadLine();

                client.CloseAsync(string.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
