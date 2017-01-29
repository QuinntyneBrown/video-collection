using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace VideoCollection.Features.DigitalAssets
{
    [Authorize]
    [RoutePrefix("api/digitalAsset")]
    public class DigitalAssetController : ApiController
    {
        public DigitalAssetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateDigitalAssetCommand.AddOrUpdateDigitalAssetResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateDigitalAssetCommand.AddOrUpdateDigitalAssetRequest request)
            => Ok(await _mediator.SendAsync(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateDigitalAssetCommand.AddOrUpdateDigitalAssetResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateDigitalAssetCommand.AddOrUpdateDigitalAssetRequest request)
            => Ok(await _mediator.SendAsync(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetDigitalAssetsQuery.GetDigitalAssetsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.SendAsync(new GetDigitalAssetsQuery.GetDigitalAssetsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetDigitalAssetByIdQuery.GetDigitalAssetByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetDigitalAssetByIdQuery.GetDigitalAssetByIdRequest request)
            => Ok(await _mediator.SendAsync(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveDigitalAssetCommand.RemoveDigitalAssetResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveDigitalAssetCommand.RemoveDigitalAssetRequest request)
            => Ok(await _mediator.SendAsync(request));

        protected readonly IMediator _mediator;

    }
}
