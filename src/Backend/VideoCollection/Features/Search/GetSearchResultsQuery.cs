using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search;

namespace VideoCollection.Features.Search
{
    public class GetSearchResultsQuery
    {
        public class GetSearchResultsRequest : IRequest<GetSearchResultsResponse> {
            public string Query { get; set; }
            public int? Top { get; set; }
            public int? Skip { get; set; }
            public string Filter { get; set; }
        }

        public class GetSearchResultsResponse
        {
            public DocumentSearchResult Result { get; set; }
        }

        public class GetSearchResultsHandler : IAsyncRequestHandler<GetSearchResultsRequest, GetSearchResultsResponse>
        {
            public GetSearchResultsHandler(
                ISearchConfiguration searchConfiguration
                ) {
                _documentOperations = new SearchIndexClient(
                    searchConfiguration.SearchServiceName, 
                    searchConfiguration.IndexName, 
                    new SearchCredentials(searchConfiguration.ApiKey)).Documents;
            }

            public async Task<GetSearchResultsResponse> Handle(GetSearchResultsRequest request)
            {
                SearchParameters searchParameters = CreateSearchParameters(QueryType.Full,SearchMode.All,null,null,null,null);
                return new GetSearchResultsResponse()
                {
                    Result = await _documentOperations.SearchAsync(request.Query, searchParameters)
                };
            }

            protected virtual SearchParameters CreateSearchParameters(QueryType queryType, SearchMode searchMode, List<string> highlightFields, int? skip, string filter, int? top)
                => new SearchParameters()
                {
                    SearchMode = searchMode,
                    QueryType = queryType,
                    IncludeTotalResultCount = true,
                    HighlightFields = highlightFields,
                    Top = top,
                    Skip = skip,
                    Filter = filter,
                    Facets = new List<string>()
                };

            private IDocumentsOperations _documentOperations { get; set; }
        }
    }
}