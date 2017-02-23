using MediatR;
using Microsoft.Practices.Unity;
using VideoCollection.Security;
using VideoCollection.Utilities;

namespace VideoCollection.Cli
{
    public class UnityConfiguration
    {
        public static IUnityContainer GetContainer()
        {
            var container = new UnityContainer()
                .AddMediator<VideoCollection.UnityConfiguration, VideoCollection.Cli.UnityConfiguration>();

            container.RegisterInstance(AuthConfiguration.LazyConfig);
            container.RegisterInstance(RedisCacheConfiguration.Config);
            return container;
        }        
    }    
}
