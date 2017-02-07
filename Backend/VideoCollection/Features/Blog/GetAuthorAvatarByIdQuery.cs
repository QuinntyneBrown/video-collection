using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.Blog
{
    public class GetAuthorAvatarByIdQuery
    {
        public class GetAuthorAvatarByIdRequest : IRequest<GetAuthorAvatarByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetAuthorAvatarByIdResponse
        {
            public AuthorAvatarApiModel AuthorAvatar { get; set; } 
		}

        public class GetAuthorAvatarByIdHandler : IAsyncRequestHandler<GetAuthorAvatarByIdRequest, GetAuthorAvatarByIdResponse>
        {
            public GetAuthorAvatarByIdHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetAuthorAvatarByIdResponse> Handle(GetAuthorAvatarByIdRequest request)
            {                
                return new GetAuthorAvatarByIdResponse()
                {
                    AuthorAvatar = AuthorAvatarApiModel.FromAuthorAvatar(await _dataContext.AuthorAvatars.FindAsync(request.Id))
                };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
