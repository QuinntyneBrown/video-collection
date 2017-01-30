using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using static VideoCollection.Features.Videos.AddOrUpdateVideoCommand;
using static VideoCollection.Features.Videos.GetVideoByIdQuery;
using static VideoCollection.Features.Videos.RemoveVideoCommand;

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
        [ResponseType(typeof(AddOrUpdateVideoResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateVideoRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateVideoResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateVideoRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetVideosQuery.GetVideosResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetVideosQuery.GetVideosRequest()));

        [Route("getbyid")]
        [HttpGet]
        [ResponseType(typeof(GetVideoByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetVideoByIdRequest request)
            => Ok(await _mediator.Send(request));

        [AllowAnonymous]
        [Route("getbyslug")]
        [HttpGet]
        [ResponseType(typeof(GetVideoBySlugQuery.GetVideoBySlugResponse))]
        public async Task<IHttpActionResult> GetBySlug([FromUri]GetVideoBySlugQuery.GetVideoBySlugRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveVideoResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveVideoRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}
