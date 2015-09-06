namespace Spike.Contracts.Users
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    [ServiceContract]
    public interface IUserProvider
    {
        [OperationContract]
        User AddUser(AddUserRequest request);

        [OperationContract]
        User GetUser(Guid id);

        [OperationContract]
        IEnumerable<User> GetUsers();
    }
}
