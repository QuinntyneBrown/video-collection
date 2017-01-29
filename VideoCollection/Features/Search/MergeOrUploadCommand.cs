using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using VideoCollection.Data.Models;

namespace VideoCollection.Features.Search
{
    public class MergeOrUploadCommand
    {
        public class MergeOrUploadRequest : IAsyncRequest<MergeOrUploadResponse> { }

        public class MergeOrUploadResponse { }

        public class MergeOrUploadHandler : IAsyncRequestHandler<MergeOrUploadRequest, MergeOrUploadResponse>
        {
            public MergeOrUploadHandler(VideoCollectionDataContext dataContext, ICache cache, ISearchConfiguration searchConfiguration)
            {
                _dataContext = dataContext;                
                _searchIndexClient = new SearchIndexClient(
                    searchConfiguration.SearchServiceName,
                    searchConfiguration.IndexName,
                    new SearchCredentials(searchConfiguration.ApiKey)); 
            }

            public Document FromVideo(Video video)
            {
                var document = new Document();
                document.Add("id", $"{video.Id}");
                document.Add("name", video.Name);
                document.Add("description", video.Description);
                document.Add("abstract", video.Abstract);
                document.Add("youTubeVideoId", video.YouTubeVideoId);
                return document;
            }

            public async Task<MergeOrUploadResponse> Handle(MergeOrUploadRequest request)
            {
                var videos = await _dataContext.Videos.ToListAsync();
                List<Document> documents = videos.Select(x => FromVideo(x)).ToList();
                IndexBatch batch = IndexBatch.MergeOrUpload(documents);
                DocumentIndexResult documentIndexResult = _searchIndexClient.Documents.Index(batch);
                return new MergeOrUploadResponse();                
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
            private SearchIndexClient _searchIndexClient { get; set; }
        }
    }
}
