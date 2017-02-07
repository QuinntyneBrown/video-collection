using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace VideoCollection.Features.HTMLContents
{
    [Authorize]
    [RoutePrefix("api/hTMLContent")]
    public class HTMLContentController : ApiController
    {
        public HTMLContentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateHTMLContentCommand.AddOrUpdateHTMLContentResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateHTMLContentCommand.AddOrUpdateHTMLContentRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateHTMLContentCommand.AddOrUpdateHTMLContentResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateHTMLContentCommand.AddOrUpdateHTMLContentRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetHTMLContentsQuery.GetHTMLContentsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetHTMLContentsQuery.GetHTMLContentsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetHTMLContentByIdQuery.GetHTMLContentByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetHTMLContentByIdQuery.GetHTMLContentByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveHTMLContentCommand.RemoveHTMLContentResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveHTMLContentCommand.RemoveHTMLContentRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}
