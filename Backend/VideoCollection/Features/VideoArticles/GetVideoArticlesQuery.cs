using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.VideoArticles
{
    public class GetVideoArticlesQuery
    {
        public class GetVideoArticlesRequest : IRequest<GetVideoArticlesResponse> { }

        public class GetVideoArticlesResponse
        {
            public ICollection<VideoArticleApiModel> VideoArticles { get; set; } = new HashSet<VideoArticleApiModel>();
        }

        public class GetVideoArticlesHandler : IAsyncRequestHandler<GetVideoArticlesRequest, GetVideoArticlesResponse>
        {
            public GetVideoArticlesHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetVideoArticlesResponse> Handle(GetVideoArticlesRequest request)
            {
                var videoArticles = await _dataContext.VideoArticles.ToListAsync();
                return new GetVideoArticlesResponse()
                {
                    VideoArticles = videoArticles.Select(x => VideoArticleApiModel.FromVideoArticle(x)).ToList()
                };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
