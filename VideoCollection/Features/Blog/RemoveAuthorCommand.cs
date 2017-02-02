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
    public class RemoveAuthorCommand
    {
        public class RemoveAuthorRequest : IRequest<RemoveAuthorResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveAuthorResponse { }

        public class RemoveAuthorHandler : IAsyncRequestHandler<RemoveAuthorRequest, RemoveAuthorResponse>
        {
            public RemoveAuthorHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveAuthorResponse> Handle(RemoveAuthorRequest request)
            {
                var author = await _dataContext.Authors.FindAsync(request.Id);
                author.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveAuthorResponse();
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
