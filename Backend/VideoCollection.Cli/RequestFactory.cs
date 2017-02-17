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
            if(typeof(TRequest) == typeof(Commands.ListAllVideosCommand.ListAllVideosRequest))
                return new Commands.ListAllVideosCommand.ListAllVideosRequest() as IRequest<TResponse>;

            throw new NotImplementedException();
        }
    }
}
