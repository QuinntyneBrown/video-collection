using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.Playlists
{
    public class GetPlaylistItemsQuery
    {
        public class GetPlaylistItemsRequest : IAsyncRequest<GetPlaylistItemsResponse> { }

        public class GetPlaylistItemsResponse
        {
            public ICollection<PlaylistItemApiModel> PlaylistItems { get; set; } = new HashSet<PlaylistItemApiModel>();
        }

        public class GetPlaylistItemsHandler : IAsyncRequestHandler<GetPlaylistItemsRequest, GetPlaylistItemsResponse>
        {
            public GetPlaylistItemsHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetPlaylistItemsResponse> Handle(GetPlaylistItemsRequest request)
            {
                var playlistItems = await _dataContext.PlaylistItems.ToListAsync();
                return new GetPlaylistItemsResponse()
                {
                    PlaylistItems = playlistItems.Select(x => PlaylistItemApiModel.FromPlaylistItem(x)).ToList()
                };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
