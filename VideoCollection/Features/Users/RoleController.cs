using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace VideoCollection.Features.Users
{
    [Authorize]
    [RoutePrefix("api/role")]
    public class RoleController : ApiController
    {
        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateRoleCommand.AddOrUpdateRoleResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateRoleCommand.AddOrUpdateRoleRequest request)
            => Ok(await _mediator.SendAsync(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateRoleCommand.AddOrUpdateRoleResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateRoleCommand.AddOrUpdateRoleRequest request)
            => Ok(await _mediator.SendAsync(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetRolesQuery.GetRolesResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.SendAsync(new GetRolesQuery.GetRolesRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetRoleByIdQuery.GetRoleByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetRoleByIdQuery.GetRoleByIdRequest request)
            => Ok(await _mediator.SendAsync(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveRoleCommand.RemoveRoleResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveRoleCommand.RemoveRoleRequest request)
            => Ok(await _mediator.SendAsync(request));

        protected readonly IMediator _mediator;

    }
}
