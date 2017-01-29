using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace VideoCollection.Features.Search
{
    [Authorize]
    [RoutePrefix("api/searchResult")]
    public class SearchResultController : ApiController
    {
        public SearchResultController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetSearchResultsQuery.GetSearchResultsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.SendAsync(new GetSearchResultsQuery.GetSearchResultsRequest()));
        
        protected readonly IMediator _mediator;

    }
}
