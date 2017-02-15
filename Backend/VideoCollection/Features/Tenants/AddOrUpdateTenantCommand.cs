using MediatR;
using VideoCollection.Data;
using VideoCollection.Data.Models;
using VideoCollection.Utilities;
using System.Threading.Tasks;
using System.Data.Entity;

namespace VideoCollection.Features.Tenants
{
    public class AddOrUpdateTenantCommand
    {
        public class AddOrUpdateTenantRequest : IRequest<AddOrUpdateTenantResponse>
        {
            public TenantApiModel Tenant { get; set; }
        }

        public class AddOrUpdateTenantResponse { }

        public class AddOrUpdateTenantHandler : IAsyncRequestHandler<AddOrUpdateTenantRequest, AddOrUpdateTenantResponse>
        {
            public AddOrUpdateTenantHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<AddOrUpdateTenantResponse> Handle(AddOrUpdateTenantRequest request)
            {
                var entity = await _dataContext.Tenants
                    .SingleOrDefaultAsync(x => x.Id == request.Tenant.Id && x.IsDeleted == false);
                if (entity == null) _dataContext.Tenants.Add(entity = new Tenant());
                entity.Name = request.Tenant.Name;
                await _dataContext.SaveChangesAsync();
                return new AddOrUpdateTenantResponse() { };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}
