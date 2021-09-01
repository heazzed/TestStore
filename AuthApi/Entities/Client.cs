using System;
using System.Collections.Generic;

#nullable disable

namespace TestStore.AuthApi.Entities
{
    public partial class Client
    {
        public string OrderId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual Order Order { get; set; }
    }
}
