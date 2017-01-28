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
    public class AddOrUpdatePlaylistItemCommand
    {
        public class AddOrUpdatePlaylistItemRequest : IAsyncRequest<AddOrUpdatePlaylistItemResponse>
        {
            public PlaylistItemApiModel PlaylistItem { get; set; }
        }

        public class AddOrUpdatePlaylistItemResponse
        {

        }

        public class AddOrUpdatePlaylistItemHandler : IAsyncRequestHandler<AddOrUpdatePlaylistItemRequest, AddOrUpdatePlaylistItemResponse>
        {
            public AddOrUpdatePlaylistItemHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdatePlaylistItemResponse> Handle(AddOrUpdatePlaylistItemRequest request)
            {
                var entity = await _dataContext.PlaylistItems
                    .SingleOrDefaultAsync(x => x.Id == request.PlaylistItem.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.PlaylistItems.Add(entity = new PlaylistItem());
                entity.Name = request.PlaylistItem.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdatePlaylistItemResponse()
                {

                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
