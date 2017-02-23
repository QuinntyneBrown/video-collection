namespace VideoCollection.Features.Search
{    
    public interface ISearchConfiguration
    {
        string SearchServiceName { get; set; }
        string IndexName { get; set; }
        string ApiKey { get; set; }
        string QueryApiKey { get; set; }
    }
}
