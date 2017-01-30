using System;
using System.Configuration;

namespace VideoCollection.Utilities
{    
    public class RedisCacheConfiguration: ConfigurationSection, IRedisCacheConfiguration
    {

        [ConfigurationProperty("apiKey")]
        public string ApiKey
        {
            get { return (string)this["apiKey"]; }
            set { this["apiKey"] = value; }
        }

        [ConfigurationProperty("connectionString")]
        public string ConnectionString
        {
            get { return (string)this["connectionString"]; }
            set { this["connectionString"] = value; }
        }

        public static IRedisCacheConfiguration Config
        {
            get { return ConfigurationManager.GetSection("redisCacheConfiguration") as IRedisCacheConfiguration; }
        }
    }
}
