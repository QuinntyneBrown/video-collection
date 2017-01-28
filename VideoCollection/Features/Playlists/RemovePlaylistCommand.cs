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
    public class RemovePlaylistCommand
    {
        public class RemovePlaylistRequest : IAsyncRequest<RemovePlaylistResponse>
        {
            public int Id { get; set; }
        }

        public class RemovePlaylistResponse { }

        public class RemovePlaylistHandler : IAsyncRequestHandler<RemovePlaylistRequest, RemovePlaylistResponse>
        {
            public RemovePlaylistHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemovePlaylistResponse> Handle(RemovePlaylistRequest request)
            {
                var playlist = await _dataContext.Playlists.FindAsync(request.Id);
                playlist.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemovePlaylistResponse();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
