namespace VideoCollection.Utilities
{    
    public interface IRedisCacheConfiguration
    {
		string ApiKey { get; set; }
        string ConnectionString { get; set; }
    }
}
