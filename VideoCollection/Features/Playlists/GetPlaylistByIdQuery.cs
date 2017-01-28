using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.Playlists
{
    public class GetPlaylistByIdQuery
    {
        public class GetPlaylistByIdRequest : IAsyncRequest<GetPlaylistByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetPlaylistByIdResponse
        {
            public PlaylistApiModel Playlist { get; set; } 
		}

        public class GetPlaylistByIdHandler : IAsyncRequestHandler<GetPlaylistByIdRequest, GetPlaylistByIdResponse>
        {
            public GetPlaylistByIdHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetPlaylistByIdResponse> Handle(GetPlaylistByIdRequest request)
            {                
                return new GetPlaylistByIdResponse()
                {
                    Playlist = PlaylistApiModel.FromPlaylist(await _dataContext.Playlists.FindAsync(request.Id))
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
