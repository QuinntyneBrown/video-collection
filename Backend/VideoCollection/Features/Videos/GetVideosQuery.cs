using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.Videos
{
    public class GetVideosQuery
    {
        public class GetVideosRequest : IRequest<GetVideosResponse> { }

        public class GetVideosResponse
        {
            public ICollection<VideoApiModel> Videos { get; set; } = new HashSet<VideoApiModel>();
        }

        public class GetVideosHandler : IAsyncRequestHandler<GetVideosRequest, GetVideosResponse>
        {
            public GetVideosHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetVideosResponse> Handle(GetVideosRequest request)
            {
                var videos = await _dataContext.Videos.ToListAsync();
                return new GetVideosResponse()
                {
                    Videos = videos.Select(x => VideoApiModel.FromVideo(x)).ToList()
                };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
