using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace VideoCollection.Features.Playlists
{
    [Authorize]
    [RoutePrefix("api/playlist")]
    public class PlaylistController : ApiController
    {
        public PlaylistController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdatePlaylistCommand.AddOrUpdatePlaylistResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdatePlaylistCommand.AddOrUpdatePlaylistRequest request)
            => Ok(await _mediator.SendAsync(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdatePlaylistCommand.AddOrUpdatePlaylistResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdatePlaylistCommand.AddOrUpdatePlaylistRequest request)
            => Ok(await _mediator.SendAsync(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetPlaylistsQuery.GetPlaylistsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.SendAsync(new GetPlaylistsQuery.GetPlaylistsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetPlaylistByIdQuery.GetPlaylistByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetPlaylistByIdQuery.GetPlaylistByIdRequest request)
            => Ok(await _mediator.SendAsync(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemovePlaylistCommand.RemovePlaylistResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemovePlaylistCommand.RemovePlaylistRequest request)
            => Ok(await _mediator.SendAsync(request));

        protected readonly IMediator _mediator;

    }
}
