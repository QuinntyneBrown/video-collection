using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.Tenants
{
    public class GetTenantByIdQuery
    {
        public class GetTenantByIdRequest : IRequest<GetTenantByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetTenantByIdResponse
        {
            public TenantApiModel Tenant { get; set; } 
		}

        public class GetTenantByIdHandler : IAsyncRequestHandler<GetTenantByIdRequest, GetTenantByIdResponse>
        {
            public GetTenantByIdHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetTenantByIdResponse> Handle(GetTenantByIdRequest request)
                =>  new GetTenantByIdResponse()
                {
                    Tenant = TenantApiModel.FromTenant(await _dataContext.Tenants.FindAsync(request.Id))
                };
            

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
