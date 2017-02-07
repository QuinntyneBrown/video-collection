using MediatR;
using VideoCollection.Data;
using VideoCollection.Data.Models;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.Blog
{
    public class RemoveTagCommand
    {
        public class RemoveTagRequest : IRequest<RemoveTagResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveTagResponse { }

        public class RemoveTagHandler : IAsyncRequestHandler<RemoveTagRequest, RemoveTagResponse>
        {
            public RemoveTagHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveTagResponse> Handle(RemoveTagRequest request)
            {
                var tag = await _dataContext.Tags.FindAsync(request.Id);
                tag.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveTagResponse();
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
