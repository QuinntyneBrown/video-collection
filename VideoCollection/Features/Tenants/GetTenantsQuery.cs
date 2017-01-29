using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.Tenants
{
    public class GetTenantsQuery
    {
        public class GetTenantsRequest : IAsyncRequest<GetTenantsResponse> { }

        public class GetTenantsResponse
        {
            public ICollection<TenantApiModel> Tenants { get; set; } = new HashSet<TenantApiModel>();
        }

        public class GetTenantsHandler : IAsyncRequestHandler<GetTenantsRequest, GetTenantsResponse>
        {
            public GetTenantsHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetTenantsResponse> Handle(GetTenantsRequest request)
            {
                var tenants = await _dataContext.Tenants.ToListAsync();
                return new GetTenantsResponse()
                {
                    Tenants = tenants.Select(x => TenantApiModel.FromTenant(x)).ToList()
                };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
