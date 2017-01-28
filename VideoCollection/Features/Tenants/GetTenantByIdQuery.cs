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
        public class GetTenantByIdRequest : IAsyncRequest<GetTenantByIdResponse> { 
			public int Id { get; set; }
		}

        public class GetTenantByIdResponse
        {
            public TenantApiModel Tenant { get; set; } 
		}

        public class GetTenantByIdHandler : IAsyncRequestHandler<GetTenantByIdRequest, GetTenantByIdResponse>
        {
            public GetTenantByIdHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetTenantByIdResponse> Handle(GetTenantByIdRequest request)
            {                
                return new GetTenantByIdResponse()
                {
                    Tenant = TenantApiModel.FromTenant(await _dataContext.Tenants.FindAsync(request.Id))
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
