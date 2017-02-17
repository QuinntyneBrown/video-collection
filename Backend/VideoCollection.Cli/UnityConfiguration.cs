using Microsoft.Practices.Unity;

namespace VideoCollection.Cli
{
    public class UnityConfiguration
    {
        public static IUnityContainer GetContainer()
        {
            var container = new UnityContainer();

            return container;
        }
    }
}
