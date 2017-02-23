using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.VideoArticles
{
    public class GetVideoArticleByIdQuery
    {
        public class GetVideoArticleByIdRequest : IRequest<GetVideoArticleByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetVideoArticleByIdResponse
        {
            public VideoArticleApiModel VideoArticle { get; set; } 
		}

        public class GetVideoArticleByIdHandler : IAsyncRequestHandler<GetVideoArticleByIdRequest, GetVideoArticleByIdResponse>
        {
            public GetVideoArticleByIdHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetVideoArticleByIdResponse> Handle(GetVideoArticleByIdRequest request)
            {                
                return new GetVideoArticleByIdResponse()
                {
                    VideoArticle = VideoArticleApiModel.FromVideoArticle(await _dataContext.VideoArticles.FindAsync(request.Id))
                };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
