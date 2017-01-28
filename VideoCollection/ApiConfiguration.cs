using Owin;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.Practices.Unity;
using Microsoft.Owin.Security.OAuth;
using Swashbuckle.Application;
using Microsoft.Owin.Cors;
using System;
using VideoCollection.Utilities;
using VideoCollection.Security;
using VideoCollection.Filters;
using MediatR;

namespace VideoCollection
{
    public class ApiConfiguration
    {
        public static void Install(HttpConfiguration config, IAppBuilder app)
        {
            WebApiUnityActionFilterProvider.RegisterFilterProviders(config);
            var container = UnityConfiguration.GetContainer();
            app.MapSignalR();


            config.Filters.Add(new HandleErrorAttribute(UnityConfiguration.GetContainer().Resolve<ILoggerFactory>()));

            app.UseCors(CorsOptions.AllowAll);

            config.SuppressHostPrincipal();

            var mediator = container.Resolve<IMediator>();
            Lazy<IAuthConfiguration> lazyAuthConfiguration = UnityConfiguration.GetContainer().Resolve<Lazy<IAuthConfiguration>>();

            config
                .EnableSwagger(c => c.SingleApiVersion("v1", "VideoCollection"))
                .EnableSwaggerUi();

            app.UseOAuthAuthorizationServer(new OAuthOptions(lazyAuthConfiguration, mediator));

            app.UseJwtBearerAuthentication(new JwtOptions(lazyAuthConfiguration));

            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            var jSettings = new JsonSerializerSettings();
            jSettings.Formatting = Formatting.Indented;
            jSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings = jSettings;
            config.MapHttpAttributeRoutes();
        }
    }
}
