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
    public class RemoveAuthorAvatarCommand
    {
        public class RemoveAuthorAvatarRequest : IRequest<RemoveAuthorAvatarResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveAuthorAvatarResponse { }

        public class RemoveAuthorAvatarHandler : IAsyncRequestHandler<RemoveAuthorAvatarRequest, RemoveAuthorAvatarResponse>
        {
            public RemoveAuthorAvatarHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveAuthorAvatarResponse> Handle(RemoveAuthorAvatarRequest request)
            {
                var authorAvatar = await _dataContext.AuthorAvatars.FindAsync(request.Id);
                authorAvatar.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveAuthorAvatarResponse();
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
