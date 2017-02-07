using Owin;
using System.Web.Http;
using Microsoft.Owin;
using Unity.WebApi;
using static VideoCollection.ApiConfiguration;

[assembly: OwinStartup(typeof(VideoCollection.Web.Startup))]

namespace VideoCollection.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
            GlobalConfiguration.Configure(config =>
            {
                config.DependencyResolver = new UnityDependencyResolver(UnityConfiguration.GetContainer());
                Install(config, app);
            });
        }
    }
}
