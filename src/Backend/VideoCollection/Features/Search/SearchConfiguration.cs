using System;
using System.Configuration;

namespace VideoCollection.Features.Search
{    
    public class SearchConfiguration: ConfigurationSection, ISearchConfiguration
    {

        [ConfigurationProperty("searchServiceName")]
        public string SearchServiceName
        {
            get { return (string)this["searchServiceName"]; }
            set { this["searchServiceName"] = value; }
        }

        [ConfigurationProperty("indexName")]
        public string IndexName
        {
            get { return (string)this["indexName"]; }
            set { this["indexName"] = value; }
        }

        [ConfigurationProperty("apiKey")]
        public string ApiKey
        {
            get { return (string)this["apiKey"]; }
            set { this["apiKey"] = value; }
        }

        [ConfigurationProperty("queryApiKey")]
        public string QueryApiKey
        {
            get { return (string)this["queryApiKey"]; }
            set { this["queryApiKey"] = value; }
        }

        public static ISearchConfiguration Config
        {
            get { return ConfigurationManager.GetSection("searchConfiguration") as ISearchConfiguration; }
        }
    }
}