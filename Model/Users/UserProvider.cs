
namespace Spike.Model.Users
{
    using System;
    using System.Collections.Generic;
    using Contracts.Users;

    public class UserProvider : IUserProvider
    {
        private readonly IUserAdapter _userAdapter;

        public UserProvider()
            : this(DependencyFactory.Resolve<IUserAdapter>())
        {}

        public UserProvider(IUserAdapter userAdapter)
        {
            this._userAdapter = userAdapter;
        }

        public User AddUser(AddUserRequest request)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Surname = request.Surname,
                Birthday = request.Birthday
            };

            return _userAdapter.AddUser(user);
        }

        public User GetUser(Guid id)
        {
            return _userAdapter.GetUser(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _userAdapter.GetUsers();
        }
    }
}
