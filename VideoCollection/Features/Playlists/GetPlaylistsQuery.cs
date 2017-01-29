using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.Playlists
{
    public class GetPlaylistsQuery
    {
        public class GetPlaylistsRequest : IAsyncRequest<GetPlaylistsResponse> { }

        public class GetPlaylistsResponse
        {
            public ICollection<PlaylistApiModel> Playlists { get; set; } = new HashSet<PlaylistApiModel>();
        }

        public class GetPlaylistsHandler : IAsyncRequestHandler<GetPlaylistsRequest, GetPlaylistsResponse>
        {
            public GetPlaylistsHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetPlaylistsResponse> Handle(GetPlaylistsRequest request)
            {
                var playlists = await _dataContext.Playlists.ToListAsync();
                return new GetPlaylistsResponse()
                {
                    Playlists = playlists.Select(x => PlaylistApiModel.FromPlaylist(x)).ToList()
                };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
