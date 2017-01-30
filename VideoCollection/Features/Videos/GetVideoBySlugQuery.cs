using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.Videos
{
    public class GetVideoBySlugQuery
    {
        public class GetVideoBySlugRequest : IRequest<GetVideoBySlugResponse>
        {
            public string Slug { get; set; }
        }

        public class GetVideoBySlugResponse
        {
            public VideoApiModel Video { get; set; }
        }

        public class GetVideoBySlugHandler : IAsyncRequestHandler<GetVideoBySlugRequest, GetVideoBySlugResponse>
        {
            public GetVideoBySlugHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetVideoBySlugResponse> Handle(GetVideoBySlugRequest request)
            {
                return new GetVideoBySlugResponse()
                {
                    Video = VideoApiModel.FromVideo(await _dataContext.Videos.SingleAsync(x=>x.Slug == request.Slug))
                };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
