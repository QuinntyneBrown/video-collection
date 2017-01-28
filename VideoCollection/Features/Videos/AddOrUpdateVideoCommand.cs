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
        public class AddOrUpdateVideoRequest : IAsyncRequest<AddOrUpdateVideoResponse>
        {
            public VideoApiModel Video { get; set; }
        }

        public class AddOrUpdateVideoResponse
        {

        }

        public class AddOrUpdateVideoHandler : IAsyncRequestHandler<AddOrUpdateVideoRequest, AddOrUpdateVideoResponse>
        {
            public AddOrUpdateVideoHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateVideoResponse> Handle(AddOrUpdateVideoRequest request)
            {
                var entity = await _dataContext.Videos
                    .SingleOrDefaultAsync(x => x.Id == request.Video.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Videos.Add(entity = new Video());
                entity.Name = request.Video.Name;
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateVideoResponse()
                {

                };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
