using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace VideoCollection.Features.VideoArticles
{
    [Authorize]
    [RoutePrefix("api/videoArticle")]
    public class VideoArticleController : ApiController
    {
        public VideoArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateVideoArticleCommand.AddOrUpdateVideoArticleResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateVideoArticleCommand.AddOrUpdateVideoArticleRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateVideoArticleCommand.AddOrUpdateVideoArticleResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateVideoArticleCommand.AddOrUpdateVideoArticleRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetVideoArticlesQuery.GetVideoArticlesResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetVideoArticlesQuery.GetVideoArticlesRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetVideoArticleByIdQuery.GetVideoArticleByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetVideoArticleByIdQuery.GetVideoArticleByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveVideoArticleCommand.RemoveVideoArticleResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveVideoArticleCommand.RemoveVideoArticleRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}
