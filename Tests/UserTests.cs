namespace Spike.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Model.Users;
    using Builders;

    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void TestUserAddSuccess()
        {
            var provider = new UserProvider();
            var request = new UserBuilder().TestUser().BuildRequest();

            var response = provider.AddUser(request);
            var found = provider.GetUser(response.Id);

            Assert.IsNotNull(found);
        }
    }
}
