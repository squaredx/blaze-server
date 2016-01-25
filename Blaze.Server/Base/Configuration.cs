using System.Collections.Generic;
using System.IO;

using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace Blaze.Server
{
    public class Configuration
    {
        public struct Config
        {
            public bool Secure { get; set; }

            public string BlazeHubServerCertificate { get; set; }

            public string BlazeServerCertificate { get; set; }

            public List<User> Users { get; set; }
        }

        public static void Load(string filename)
        {
            var buffer = File.ReadAllText(filename);

            var deserializer = new Deserializer(ignoreUnmatched: true);
            var config = deserializer.Deserialize<Config>(new StringReader(buffer));

            Secure = config.Secure;
            BlazeHubServerCertificate = config.BlazeHubServerCertificate;
            BlazeServerCertificate = config.BlazeServerCertificate;
            Users = config.Users;
        }

        public static bool Secure { get; set; }

        public static string BlazeHubServerCertificate { get; set; }

        public static string BlazeServerCertificate { get; set; }

        public static List<User> Users { get; set; }
    }

    public class User
    {
        public ulong ID { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }
    }
}
