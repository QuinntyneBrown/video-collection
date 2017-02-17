using System;
using MediatR;

namespace VideoCollection.Cli
{
    public interface IRequestFactory         
    {
        IRequest<TResponse> MakeRequest<TRequest, TResponse> (string[] args)
            where TRequest : IRequest<TResponse>;
    }

    public class RequestFactory : IRequestFactory
    {
        public IRequest<TResponse> MakeRequest<TRequest, TResponse>(string[] args) 
            where TRequest : IRequest<TResponse>
        {
            if(typeof(TRequest) == typeof(Commands.Videos.ListAllVideosCommand.ListAllVideosRequest))
                return new Commands.Videos.ListAllVideosCommand.ListAllVideosRequest() as IRequest<TResponse>;

            if (typeof(TRequest) == typeof(Commands.MainMenuCommand.MainMenuRequest))
                return new Commands.MainMenuCommand.MainMenuRequest() as IRequest<TResponse>;

            throw new NotImplementedException();
        }
    }
}
