namespace Spike.Host
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using Model.Users;

    public class ServiceManager
    {
        readonly List<ServiceHost> _serviceHosts = new List<ServiceHost>();

        public void OpenAll()
        {
            OpenHost<UserProvider>();
        }

        public void CloseAll()
        {
            foreach (var serviceHost in _serviceHosts)
                serviceHost.Close();
        }

        private void OpenHost<T>()
        {
            var type = typeof(T);
            var serviceHost = new ServiceHost(type);
            serviceHost.Open();
            _serviceHosts.Add(serviceHost);
        }
    }  
}
