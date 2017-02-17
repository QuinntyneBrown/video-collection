using MediatR;
using System.Threading.Tasks;
using static VideoCollection.Features.Videos.GetVideosQuery;
using System;

namespace VideoCollection.Cli.Commands
{
    public class ListAllVideosCommand
    {
        public class ListAllVideosRequest : IRequest<ListAllVideosResponse> { }

        public class ListAllVideosResponse { }

        public class ListAllVideosHandler : IAsyncRequestHandler<ListAllVideosRequest, ListAllVideosResponse>
        {
            public ListAllVideosHandler(IMediator mediator)
            {
                _mediator = mediator;
            }

            public async Task<ListAllVideosResponse> Handle(ListAllVideosRequest request)
            {
                var videos = await _mediator.Send(new GetVideosRequest());
                foreach(var video in videos.Videos)
                {
                    Console.WriteLine($"{video.YouTubeVideoId}");
                }
                return new ListAllVideosResponse();
            }

            private IMediator _mediator { get; set; }
        }

        
    }

}
