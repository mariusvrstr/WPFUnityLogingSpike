namespace Spike.Contracts.Users
{
    using System;
    using System.Collections.Generic;

    public interface IUserAdapter
    {
        User AddUser(User user);

        User GetUser(Guid id);

        IEnumerable<User> GetUsers();
    }
}
