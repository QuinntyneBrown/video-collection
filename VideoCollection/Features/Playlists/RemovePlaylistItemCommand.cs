using MediatR;
using VideoCollection.Data;
using VideoCollection.Data.Models;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.Playlists
{
    public class RemovePlaylistItemCommand
    {
        public class RemovePlaylistItemRequest : IAsyncRequest<RemovePlaylistItemResponse>
        {
            public int Id { get; set; }
        }

        public class RemovePlaylistItemResponse { }

        public class RemovePlaylistItemHandler : IAsyncRequestHandler<RemovePlaylistItemRequest, RemovePlaylistItemResponse>
        {
            public RemovePlaylistItemHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemovePlaylistItemResponse> Handle(RemovePlaylistItemRequest request)
            {
                var playlistItem = await _dataContext.PlaylistItems.FindAsync(request.Id);
                playlistItem.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemovePlaylistItemResponse();
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
