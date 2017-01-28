using MediatR;
using VideoCollection.Data;
using VideoCollection.Data.Models;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.Tenants
{
    public class RemoveTenantCommand
    {
        public class RemoveTenantRequest : IAsyncRequest<RemoveTenantResponse>
        {
            public int Id { get; set; }
        }

        public class RemoveTenantResponse { }

        public class RemoveTenantHandler : IAsyncRequestHandler<RemoveTenantRequest, RemoveTenantResponse>
        {
            public RemoveTenantHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<RemoveTenantResponse> Handle(RemoveTenantRequest request)
            {
                var tenant = await _dataContext.Tenants.FindAsync(request.Id);
                tenant.IsDeleted = true;
                await _dataContext.SaveChangesAsync();
                return new RemoveTenantResponse();
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
