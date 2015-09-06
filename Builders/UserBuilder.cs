namespace Spike.Builders
{
    using System;
    using Contracts.Users;

    public class UserBuilder : User
    {
        public UserBuilder(Guid? id = null)
        {
            this.Id = id ?? Guid.NewGuid();
        }

        public UserBuilder TestUser()
        {
            this.Name = "John";
            this.Surname = "Doe";
            this.Birthday = new DateTime(1986, 03, 04);

            return this;
        }

        public AddUserRequest BuildRequest()
        {
            return new AddUserRequest
            {
                Name = this.Name,
                Surname = this.Surname,
                Birthday = this.Birthday
            };
        }

        public User Build()
        {
            return new User
            {
                Id = this.Id,
                Name = this.Name,
                Surname = this.Surname,
                Birthday = this.Birthday
            };
        }
    }
}
