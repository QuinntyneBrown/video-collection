using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace VideoCollection.Features.Videos
{    
    [Authorize]
    [RoutePrefix("api/video")]
    public class VideoController : ApiController
    {
        public VideoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateVideoCommand.AddOrUpdateVideoResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateVideoCommand.AddOrUpdateVideoRequest request)
            => Ok(await _mediator.SendAsync(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateVideoCommand.AddOrUpdateVideoResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateVideoCommand.AddOrUpdateVideoRequest request)
            => Ok(await _mediator.SendAsync(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetVideosQuery.GetVideosResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.SendAsync(new GetVideosQuery.GetVideosRequest()));

        [Route("getbyid")]
        [HttpGet]
        [ResponseType(typeof(GetVideoByIdQuery.GetVideoByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetVideoByIdQuery.GetVideoByIdRequest request)
            => Ok(await _mediator.SendAsync(request));

        [AllowAnonymous]
        [Route("getbyslug")]
        [HttpGet]
        [ResponseType(typeof(GetVideoBySlugQuery.GetVideoBySlugResponse))]
        public async Task<IHttpActionResult> GetBySlug([FromUri]GetVideoBySlugQuery.GetVideoBySlugRequest request)
            => Ok(await _mediator.SendAsync(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveVideoCommand.RemoveVideoResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveVideoCommand.RemoveVideoRequest request)
            => Ok(await _mediator.SendAsync(request));

        protected readonly IMediator _mediator;

    }
}
