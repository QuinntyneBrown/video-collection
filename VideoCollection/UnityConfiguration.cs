using VideoCollection.Data;

using VideoCollection.Utilities;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using VideoCollection.Security;
using MediatR;

namespace VideoCollection
{
    public class UnityConfiguration
    {
        public static IUnityContainer GetContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<ILoggerFactory, LoggerFactory>();
            container.RegisterType<ICacheProvider, CacheProvider>();
            container.RegisterType<IEncryptionService, EncryptionService>();
            container.RegisterType<ILogger, Logger>();
            container.RegisterTypes(AllClasses.FromAssemblies(typeof(UnityConfiguration).Assembly), WithMappings.FromAllInterfaces);
            container.RegisterType<IMediator, Mediator>();
            container.RegisterInstance<SingleInstanceFactory>(t => container.Resolve(t));
            container.RegisterInstance<MultiInstanceFactory>(t => container.ResolveAll(t));

            container.RegisterInstance(AuthConfiguration.LazyConfig);            
            return container;
        }
    }
}
