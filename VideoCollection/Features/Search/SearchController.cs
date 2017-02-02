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
            => Ok(await _mediator.Send(request));

        [Route("suggest")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetSuggestResultsQuery.GetSuggestResultsResponse))]
        public async Task<IHttpActionResult> Suggest([FromUri]GetSuggestResultsQuery.GetSuggestResultsRequest request)
            => Ok(await _mediator.Send(request));

        [Route("upload")]        
        [HttpGet]
        [ResponseType(typeof(MergeOrUploadVideosCommand.MergeOrUploadResponse))]
        public async Task<IHttpActionResult> Upload([FromUri]MergeOrUploadVideosCommand.MergeOrUploadRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}
