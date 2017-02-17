using MediatR;
using System.Threading.Tasks;
using System;
using static VideoCollection.Cli.Commands.Videos.ListAllVideosCommand;

namespace VideoCollection.Cli.Commands
{
    public class MainMenuCommand
    {
        public class MainMenuRequest : IRequest<MainMenuResponse> { }

        public class MainMenuResponse { }

        public class MainMenuHandler : IAsyncRequestHandler<MainMenuRequest, MainMenuResponse>
        {
            public MainMenuHandler(IRequestFactory requestFactory, IMediator mediator)
            {
                _requestFactory = requestFactory;
                _mediator = mediator;
            }

            public async Task<MainMenuResponse> Handle(MainMenuRequest request)
            {
                Console.WriteLine("Press Q to Quit");
                
                string[] args;

                do
                {
                    args = Console.ReadLine().Split(new char[] { ' ' });
                    
                    if (args.Length > 0)
                    {
                        switch (args[0])
                        {
                            case "all-videos":
                                _mediator.Send(_requestFactory.MakeRequest<ListAllVideosRequest, ListAllVideosResponse>(args))
                                   .Wait();
                                break;
                        }
                    }
                }
                while (args.Length > 0 && args[0] != "q");

                return await Task.FromResult(new MainMenuResponse());
            }

            private readonly IRequestFactory _requestFactory;
            private readonly IMediator _mediator;
        }
    }

}
