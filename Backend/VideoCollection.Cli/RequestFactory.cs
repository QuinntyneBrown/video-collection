using System;
using MediatR;
using static VideoCollection.Features.Videos.GetVideosQuery;

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
            return new GetVideosRequest() as IRequest<TResponse>;
        }
    }
}
