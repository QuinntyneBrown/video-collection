using VideoCollection.Data.Models;

namespace VideoCollection.Features.Search
{
    public class SearchResultApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromSearchResult<TModel>(SearchResult searchResult) where
            TModel : SearchResultApiModel, new()
        {
            var model = new TModel();
            model.Id = searchResult.Id;
            return model;
        }

        public static SearchResultApiModel FromSearchResult(SearchResult searchResult)
            => FromSearchResult<SearchResultApiModel>(searchResult);

    }
}
