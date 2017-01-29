using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace VideoCollection.Features.Search
{
    [Authorize]
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {
        public SearchController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetSearchResultsQuery.GetSearchResultsResponse))]
        public async Task<IHttpActionResult> Get([FromUri]GetSearchResultsQuery.GetSearchResultsRequest request)
            => Ok(await _mediator.SendAsync(request));

        [Route("upload")]        
        [HttpGet]
        [ResponseType(typeof(MergeOrUploadCommand.MergeOrUploadResponse))]
        public async Task<IHttpActionResult> Upload([FromUri]MergeOrUploadCommand.MergeOrUploadRequest request)
            => Ok(await _mediator.SendAsync(request));

        protected readonly IMediator _mediator;

    }
}
