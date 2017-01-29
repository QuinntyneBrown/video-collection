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
    public class AddOrUpdatePlaylistCommand
    {
        public class AddOrUpdatePlaylistRequest : IAsyncRequest<AddOrUpdatePlaylistResponse>
        {
            public PlaylistApiModel Playlist { get; set; }
        }

        public class AddOrUpdatePlaylistResponse
        {

        }

        public class AddOrUpdatePlaylistHandler : IAsyncRequestHandler<AddOrUpdatePlaylistRequest, AddOrUpdatePlaylistResponse>
        {
            public AddOrUpdatePlaylistHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdatePlaylistResponse> Handle(AddOrUpdatePlaylistRequest request)
            {
                var entity = await _dataContext.Playlists
                    .SingleOrDefaultAsync(x => x.Id == request.Playlist.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Playlists.Add(entity = new Playlist());
                entity.Name = request.Playlist.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdatePlaylistResponse()
                {

                };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
