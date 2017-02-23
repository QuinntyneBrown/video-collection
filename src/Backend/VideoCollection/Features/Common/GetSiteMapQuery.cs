using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Threading.Tasks;

namespace VideoCollection.Features.Common
{
    public class GetSiteMapQuery
    {
        public class GetSiteMapRequest : IRequest<GetSiteMapResponse> { }

        public class GetSiteMapResponse { }

        public class GetSiteMapHandler : IAsyncRequestHandler<GetSiteMapRequest, GetSiteMapResponse>
        {
            public GetSiteMapHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetSiteMapResponse> Handle(GetSiteMapRequest request)
            {
				throw new System.NotImplementedException();
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
