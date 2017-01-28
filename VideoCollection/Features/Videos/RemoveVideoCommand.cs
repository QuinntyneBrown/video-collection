using MediatR;
using VideoCollection.Data;
using VideoCollection.Data.Models;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.Videos
{
    public class RemoveVideoCommand
    {
        public class RemoveVideoRequest : IAsyncRequest<RemoveVideoResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveVideoResponse { }

        public class RemoveVideoHandler : IAsyncRequestHandler<RemoveVideoRequest, RemoveVideoResponse>
        {
            public RemoveVideoHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveVideoResponse> Handle(RemoveVideoRequest request)
            {
                var video = await _dataContext.Videos.FindAsync(request.Id);
                video.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveVideoResponse();
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
