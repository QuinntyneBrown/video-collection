using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace VideoCollection.Features.Playlists
{
    [Authorize]
    [RoutePrefix("api/playlistItem")]
    public class PlaylistItemController : ApiController
    {
        public PlaylistItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdatePlaylistItemCommand.AddOrUpdatePlaylistItemResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdatePlaylistItemCommand.AddOrUpdatePlaylistItemRequest request)
            => Ok(await _mediator.SendAsync(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdatePlaylistItemCommand.AddOrUpdatePlaylistItemResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdatePlaylistItemCommand.AddOrUpdatePlaylistItemRequest request)
            => Ok(await _mediator.SendAsync(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetPlaylistItemsQuery.GetPlaylistItemsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.SendAsync(new GetPlaylistItemsQuery.GetPlaylistItemsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetPlaylistItemByIdQuery.GetPlaylistItemByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetPlaylistItemByIdQuery.GetPlaylistItemByIdRequest request)
            => Ok(await _mediator.SendAsync(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemovePlaylistItemCommand.RemovePlaylistItemResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemovePlaylistItemCommand.RemovePlaylistItemRequest request)
            => Ok(await _mediator.SendAsync(request));

        protected readonly IMediator _mediator;

    }
}
