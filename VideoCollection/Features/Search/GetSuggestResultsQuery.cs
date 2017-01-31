using MediatR;
using System.Threading.Tasks;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search;

namespace VideoCollection.Features.Search
{
    public class GetSuggestResultsQuery
    {
        public class GetSuggestResultsRequest : IRequest<GetSuggestResultsResponse> {
            public string Query { get; set; }
        }

        public class GetSuggestResultsResponse
        {
            public DocumentSuggestResult Result { get; set; }
        }

        public class GetSuggestResultsHandler : IAsyncRequestHandler<GetSuggestResultsRequest, GetSuggestResultsResponse>
        {
            public GetSuggestResultsHandler(
                ISearchConfiguration searchConfiguration
                ) {
                _documentOperations = new SearchIndexClient(
                    searchConfiguration.SearchServiceName, 
                    searchConfiguration.IndexName, 
                    new SearchCredentials(searchConfiguration.ApiKey)).Documents;
            }

            public async Task<GetSuggestResultsResponse> Handle(GetSuggestResultsRequest request)
            {
                return new GetSuggestResultsResponse()
                {
                    Result = await _documentOperations.SuggestAsync(request.Query,"")
                };
            }

            private IDocumentsOperations _documentOperations { get; set; }
        }
    }

}
