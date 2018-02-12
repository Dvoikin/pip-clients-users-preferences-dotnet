using PipServices.Commons.Data;
using System.Runtime.Serialization;

namespace PipServices.Users.Preferences.Client.Version1
{
    [DataContract]
    public class UserPreferencesV1 : IStringIdentifiable
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "user_id")]
        public string UserId { get; set; }

        [DataMember(Name = "preferred_email")]
        public string PreferredEmail { get; set; }

        [DataMember(Name = "time_zone")]
        public string TimeZone { get; set; }

        [DataMember(Name = "language")]
        public string Language { get; set; }

        [DataMember(Name = "theme")]
        public string Theme { get; set; }
    }
}