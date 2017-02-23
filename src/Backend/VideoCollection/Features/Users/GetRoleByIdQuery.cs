using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Threading.Tasks;

namespace VideoCollection.Features.Users
{
    public class GetRoleByIdQuery
    {
        public class GetRoleByIdRequest : IRequest<GetRoleByIdResponse> {  public int Id { get; set; } }

        public class GetRoleByIdResponse { public RoleApiModel Role { get; set; }  }

        public class GetRoleByIdHandler : IAsyncRequestHandler<GetRoleByIdRequest, GetRoleByIdResponse>
        {
            public GetRoleByIdHandler(VideoCollectionDataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetRoleByIdResponse> Handle(GetRoleByIdRequest request)
            {                
                return new GetRoleByIdResponse()
                {
                    Role = RoleApiModel.FromRole(await _dataContext.Roles.FindAsync(request.Id))
                };
            }

            private readonly VideoCollectionDataContext _dataContext;
            private readonly ICache _cache;
        }
    }
}