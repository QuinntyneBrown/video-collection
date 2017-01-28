using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.Videos
{
    public class GetVideoByIdQuery
    {
        public class GetVideoByIdRequest : IAsyncRequest<GetVideoByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetVideoByIdResponse
        {
            public VideoApiModel Video { get; set; } 
		}

        public class GetVideoByIdHandler : IAsyncRequestHandler<GetVideoByIdRequest, GetVideoByIdResponse>
        {
            public GetVideoByIdHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetVideoByIdResponse> Handle(GetVideoByIdRequest request)
            {                
                return new GetVideoByIdResponse()
                {
                    Video = VideoApiModel.FromVideo(await _dataContext.Videos.FindAsync(request.Id))
                };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
