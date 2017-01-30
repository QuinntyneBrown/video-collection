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
    public class AddOrUpdateVideoCommand
    {
        public class AddOrUpdateVideoRequest : IRequest<AddOrUpdateVideoResponse>
        {
            public VideoApiModel Video { get; set; }
        }

        public class AddOrUpdateVideoResponse { }

        public class AddOrUpdateVideoHandler : IAsyncRequestHandler<AddOrUpdateVideoRequest, AddOrUpdateVideoResponse>
        {
            public AddOrUpdateVideoHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateVideoResponse> Handle(AddOrUpdateVideoRequest request)
            {
                Video entity = await _dataContext.Videos
                    .SingleOrDefaultAsync(x => x.Id == request.Video.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Videos.Add(entity = new Video());
                entity.Title = request.Video.Title;
                entity.Description = request.Video.Description;
                entity.Category = request.Video.Category;
                entity.YouTubeVideoId = request.Video.YouTubeVideoId;
                await _dataContext.SaveChangesAsync();
                return new AddOrUpdateVideoResponse() { };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
