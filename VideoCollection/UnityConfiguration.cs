using Microsoft.Practices.Unity;
using VideoCollection.Security;
using MediatR;
using VideoCollection.Utilities;
using System;
using System.Linq;

namespace VideoCollection
{
    public class UnityConfiguration
    {
        public static IUnityContainer GetContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IMediator, Mediator>();

            var classes = AllClasses.FromAssemblies(typeof(UnityConfiguration).Assembly)
                .Where(x=>x.Name.Contains("Controller") == false)
                .ToList();

            container.RegisterTypes(classes, WithMappings.FromAllInterfaces, GetName, GetLifetimeManager);
            container.RegisterInstance<SingleInstanceFactory>(t => container.IsRegistered(t) ? container.Resolve(t) : null);
            container.RegisterInstance<MultiInstanceFactory>(t => container.ResolveAll(t));            
            container.RegisterInstance(AuthConfiguration.LazyConfig);
            container.RegisterInstance(RedisCacheConfiguration.Config);            
            return container;
        }

        static bool IsNotificationHandler(Type type)
        {
            return type.GetInterfaces().Any(x => x.IsGenericType && (x.GetGenericTypeDefinition() == typeof(INotificationHandler<>) || x.GetGenericTypeDefinition() == typeof(IAsyncNotificationHandler<>)));
        }

        static LifetimeManager GetLifetimeManager(Type type)
        {
            return IsNotificationHandler(type) ? new ContainerControlledLifetimeManager() : null;
        }

        static string GetName(Type type)
        {
            return IsNotificationHandler(type) ? string.Format("HandlerFor" + type.Name) : string.Empty;
        }
    }
}
