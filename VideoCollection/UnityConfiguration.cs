using Microsoft.Practices.Unity;
using VideoCollection.Security;
using MediatR;

using static VideoCollection.Security.AuthenticateCommand;
using static VideoCollection.Security.GetClaimsForUserQuery;
using static VideoCollection.Features.DigitalAssets.UploadDigitalAssetCommand;

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

            container.RegisterTypes(AllClasses.FromAssemblies(typeof(UnityConfiguration).Assembly),WithMappings.FromMatchingInterface,WithName.Default);
            container.RegisterType<IMediator, Mediator>();
            container.RegisterInstance<SingleInstanceFactory>(t => container.Resolve(t));
            container.RegisterInstance<MultiInstanceFactory>(t => container.ResolveAll(t));            
            container.RegisterInstance(AuthConfiguration.LazyConfig);            
            return container;
        }
    }
}
