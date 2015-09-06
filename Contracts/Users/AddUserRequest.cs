namespace Spike.Contracts.Users
{
    using System;
    using System.Runtime.Serialization;
    
    [DataContract]
    public class AddUserRequest
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public DateTime Birthday { get; set; }
    }
}
