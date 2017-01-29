using VideoCollection.Data;

using VideoCollection.Utilities;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using VideoCollection.Security;
using MediatR;
using static VideoCollection.Security.AuthenticateCommand;

namespace VideoCollection
{
    public class UnityConfiguration
    {
        public static IUnityContainer GetContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IAsyncRequestHandler<AuthenticateRequest, AuthenticateResponse>, AuthenticateHandler>();

            container.RegisterTypes(AllClasses.FromAssemblies(typeof(UnityConfiguration).Assembly),WithMappings.FromMatchingInterface,WithName.Default);
            container.RegisterType<IMediator, Mediator>();
            container.RegisterInstance<SingleInstanceFactory>(t => container.Resolve(t));
            container.RegisterInstance<MultiInstanceFactory>(t => container.ResolveAll(t));            
            container.RegisterInstance(AuthConfiguration.LazyConfig);            
            return container;
        }
    }
}
