using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace VideoCollection.Features.Blog
{
    [Authorize]
    [RoutePrefix("api/authorAvatar")]
    public class AuthorAvatarController : ApiController
    {
        public AuthorAvatarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateAuthorAvatarCommand.AddOrUpdateAuthorAvatarResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateAuthorAvatarCommand.AddOrUpdateAuthorAvatarRequest request)
            => Ok(await _mediator.Send(request));

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateAuthorAvatarCommand.AddOrUpdateAuthorAvatarResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateAuthorAvatarCommand.AddOrUpdateAuthorAvatarRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetAuthorAvatarsQuery.GetAuthorAvatarsResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetAuthorAvatarsQuery.GetAuthorAvatarsRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetAuthorAvatarByIdQuery.GetAuthorAvatarByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetAuthorAvatarByIdQuery.GetAuthorAvatarByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveAuthorAvatarCommand.RemoveAuthorAvatarResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveAuthorAvatarCommand.RemoveAuthorAvatarRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;

    }
}
