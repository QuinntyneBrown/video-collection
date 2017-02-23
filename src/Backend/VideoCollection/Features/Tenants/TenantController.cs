using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace VideoCollection.Features.Tenants
{
    [Authorize]
    [RoutePrefix("api/tenant")]
    public class TenantController : ApiController
    {
        public TenantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateTenantCommand.AddOrUpdateTenantResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateTenantCommand.AddOrUpdateTenantRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateTenantCommand.AddOrUpdateTenantResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateTenantCommand.AddOrUpdateTenantRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetTenantsQuery.GetTenantsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetTenantsQuery.GetTenantsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetTenantByIdQuery.GetTenantByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetTenantByIdQuery.GetTenantByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveTenantCommand.RemoveTenantResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveTenantCommand.RemoveTenantRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}
