using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.Blog
{
    public class GetTagByIdQuery
    {
        public class GetTagByIdRequest : IRequest<GetTagByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetTagByIdResponse
        {
            public TagApiModel Tag { get; set; } 
		}

        public class GetTagByIdHandler : IAsyncRequestHandler<GetTagByIdRequest, GetTagByIdResponse>
        {
            public GetTagByIdHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetTagByIdResponse> Handle(GetTagByIdRequest request)
            {                
                return new GetTagByIdResponse()
                {
                    Tag = TagApiModel.FromTag(await _dataContext.Tags.FindAsync(request.Id))
                };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
