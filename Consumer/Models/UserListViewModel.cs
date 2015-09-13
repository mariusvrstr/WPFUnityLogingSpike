namespace Spike.Consumer.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts.Users;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Annotations;
    using UserService;
    using Utils;
    
    using Builders;

    public class UserListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public IEnumerable<User> Users { get; set; }

        public void Initialize()
        {
            this.GetLatestUsers();
        }

        public void GetLatestUsers()
        {
            this.Users = GetUsersFromService();

            if (Users.Any()) return;

            var consumer = new ServiceClientWrapper<UserProviderClient, UserService.IUserProvider>();

            consumer.Excecute(service =>
                service.AddUser(new UserBuilder().TestUser().BuildRequest()));

            this.Users = GetUsersFromService();
        }

        private static IEnumerable<User> GetUsersFromService()
        {
            var consumer = new ServiceClientWrapper<UserProviderClient, UserService.IUserProvider>();
            if (!consumer.IsServiceAvailabe()) return new List<User>();

            return consumer.Excecute(service => service.GetUsers());
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
