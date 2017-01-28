using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.Playlists
{
    public class GetPlaylistItemByIdQuery
    {
        public class GetPlaylistItemByIdRequest : IAsyncRequest<GetPlaylistItemByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetPlaylistItemByIdResponse
        {
            public PlaylistItemApiModel PlaylistItem { get; set; } 
		}

        public class GetPlaylistItemByIdHandler : IAsyncRequestHandler<GetPlaylistItemByIdRequest, GetPlaylistItemByIdResponse>
        {
            public GetPlaylistItemByIdHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetPlaylistItemByIdResponse> Handle(GetPlaylistItemByIdRequest request)
            {                
                return new GetPlaylistItemByIdResponse()
                {
                    PlaylistItem = PlaylistItemApiModel.FromPlaylistItem(await _dataContext.PlaylistItems.FindAsync(request.Id))
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
