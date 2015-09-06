namespace Spike.Model
{
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using System.Configuration;

    public static class DependencyFactory
    {
        private const string UnitySection = "Unity";
        public static IUnityContainer Container { get; private set; }

        static DependencyFactory()
        {
            var container = new UnityContainer();

            var section = (UnityConfigurationSection) ConfigurationManager.GetSection(UnitySection);
            if (section != null)
            {
                section.Configure(container);
            }
            Container = container;
        }

        public static T Resolve<T>()
        {
            var ret = default(T);

            if (Container.IsRegistered(typeof(T)))
            {
                ret = Container.Resolve<T>();
            }

            return ret;
        }
    }
}
