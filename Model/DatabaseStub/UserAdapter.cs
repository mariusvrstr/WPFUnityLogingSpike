namespace Spike.Model.DatabaseStub
{
    using System.Linq;
    using Contracts.Users;
    using System;
    using System.Collections.Generic;

    public class UserAdapter : IUserAdapter
    {
        private static List<User> _users;
        public static  List<User> Users
        {
            get
            {
                if (_users != null)
                {
                    return _users;
                }

                return _users = new List<User>();
            }
            set { _users = value; }
        }

        public User AddUser(User user)
        {
            Users.Add(user);
            return user;
        }

        public User GetUser(Guid id)
        {
            return Users.FirstOrDefault(user => user.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return Users;
        }
    }
}
