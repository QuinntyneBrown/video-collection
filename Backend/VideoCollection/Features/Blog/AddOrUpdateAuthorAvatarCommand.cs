using MediatR;
using VideoCollection.Data;
using VideoCollection.Data.Models;
using VideoCollection.Utilities;
using System.Threading.Tasks;
using System.Data.Entity;

namespace VideoCollection.Features.Blog
{
    public class AddOrUpdateAuthorAvatarCommand
    {
        public class AddOrUpdateAuthorAvatarRequest : IRequest<AddOrUpdateAuthorAvatarResponse>
        {
            public AuthorAvatarApiModel AuthorAvatar { get; set; }
        }

        public class AddOrUpdateAuthorAvatarResponse { }

        public class AddOrUpdateAuthorAvatarHandler : IAsyncRequestHandler<AddOrUpdateAuthorAvatarRequest, AddOrUpdateAuthorAvatarResponse>
        {
            public AddOrUpdateAuthorAvatarHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateAuthorAvatarResponse> Handle(AddOrUpdateAuthorAvatarRequest request)
            {
                var entity = await _dataContext.AuthorAvatars
                    .SingleOrDefaultAsync(x => x.Id == request.AuthorAvatar.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.AuthorAvatars.Add(entity = new AuthorAvatar());
                
                await _dataContext.SaveChangesAsync();

                return new AddOrUpdateAuthorAvatarResponse() { };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
