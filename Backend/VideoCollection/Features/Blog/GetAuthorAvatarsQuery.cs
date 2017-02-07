using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.Blog
{
    public class GetAuthorAvatarsQuery
    {
        public class GetAuthorAvatarsRequest : IRequest<GetAuthorAvatarsResponse> { }

        public class GetAuthorAvatarsResponse
        {
            public ICollection<AuthorAvatarApiModel> AuthorAvatars { get; set; } = new HashSet<AuthorAvatarApiModel>();
        }

        public class GetAuthorAvatarsHandler : IAsyncRequestHandler<GetAuthorAvatarsRequest, GetAuthorAvatarsResponse>
        {
            public GetAuthorAvatarsHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetAuthorAvatarsResponse> Handle(GetAuthorAvatarsRequest request)
            {
                var authorAvatars = await _dataContext.AuthorAvatars.ToListAsync();
                return new GetAuthorAvatarsResponse()
                {
                    AuthorAvatars = authorAvatars.Select(x => AuthorAvatarApiModel.FromAuthorAvatar(x)).ToList()
                };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
