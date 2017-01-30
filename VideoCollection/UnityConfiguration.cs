using Microsoft.Practices.Unity;
using VideoCollection.Security;
using MediatR;

using static VideoCollection.Security.AuthenticateCommand;
using static VideoCollection.Security.GetClaimsForUserQuery;

using static VideoCollection.Features.DigitalAssets.UploadDigitalAssetCommand;
using static VideoCollection.Features.DigitalAssets.GetDigitalAssetsQuery;
using static VideoCollection.Features.DigitalAssets.GetDigitalAssetByIdQuery;
using static VideoCollection.Features.DigitalAssets.RemoveDigitalAssetCommand;

using static VideoCollection.Features.Videos.AddOrUpdateVideoCommand;
using static VideoCollection.Features.Videos.GetVideosQuery;
using static VideoCollection.Features.Videos.GetVideoBySlugQuery;
using static VideoCollection.Features.Videos.GetVideoByIdQuery;
using static VideoCollection.Features.Videos.RemoveVideoCommand;
using VideoCollection.Utilities;

namespace VideoCollection
{
    public class UnityConfiguration
    {
        public static IUnityContainer GetContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IAsyncRequestHandler<AuthenticateRequest, AuthenticateResponse>, AuthenticateHandler>();
            container.RegisterType<IAsyncRequestHandler<GetClaimsForUserRequest, GetClaimsForUserResponse>, GetClaimsForUserHandler>();

            container.RegisterType<IAsyncRequestHandler<UploadDigitalAssetRequest, UploadDigitalAssetResponse>, UploadDigitalAssetHandler>();
            container.RegisterType<IAsyncRequestHandler<GetDigitalAssetsRequest, GetDigitalAssetsResponse>, GetDigitalAssetsHandler>();
            container.RegisterType<IAsyncRequestHandler<GetDigitalAssetByIdRequest, GetDigitalAssetByIdResponse>, GetDigitalAssetByIdHandler>();
            container.RegisterType<IAsyncRequestHandler<RemoveDigitalAssetRequest, RemoveDigitalAssetResponse>, RemoveDigitalAssetHandler>();


            container.RegisterInstance<ICache>(VideoCollection.Utilities.RedisCache.Current);

            container.RegisterTypes(AllClasses.FromAssemblies(typeof(UnityConfiguration).Assembly),WithMappings.FromMatchingInterface,WithName.Default);
            container.RegisterType<IMediator, Mediator>();
            container.RegisterInstance<SingleInstanceFactory>(t => container.Resolve(t));
            container.RegisterInstance<MultiInstanceFactory>(t => container.ResolveAll(t));            
            container.RegisterInstance(AuthConfiguration.LazyConfig);


                    
            return container;
        }
    }
}
