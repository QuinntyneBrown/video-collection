using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace VideoCollection.Features.Users
{
    public class GetRolesQuery
    {
        public class GetRolesRequest : IAsyncRequest<GetRolesResponse> { }

        public class GetRolesResponse
        {
            public ICollection<RoleApiModel> Roles { get; set; } = new HashSet<RoleApiModel>();
        }

        public class GetRolesHandler : IAsyncRequestHandler<GetRolesRequest, GetRolesResponse>
        {
            public GetRolesHandler(QuinntyneBrownPhotographyDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetRolesResponse> Handle(GetRolesRequest request)
            {
                var roles = await _dataContext.Roles.ToListAsync();
                return new GetRolesResponse()
                {
                    Roles = roles.Select(x => RoleApiModel.FromRole(x)).ToList()
                };
            }

            private readonly QuinntyneBrownPhotographyDataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
