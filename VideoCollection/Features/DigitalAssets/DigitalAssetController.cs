using MediatR;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using VideoCollection.Features.DigitalAssets.UploadHandlers;

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

        [AllowAnonymous]
        [Route("upload")]
        [HttpPost]
        public async Task<IHttpActionResult> Upload(HttpRequestMessage request)
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var provider = await Request.Content.ReadAsMultipartAsync(new InMemoryMultipartFormDataStreamProvider());
            var response = await _mediator.SendAsync(new UploadDigitalAssetCommand.UploadDigitalAssetRequest() { Provider = provider });
            return Ok(response);
        }

        protected readonly IMediator _mediator;

    }
}
