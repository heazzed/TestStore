using System;
using System.Collections.Generic;

#nullable disable

namespace TestStore.AuthApi.Entities
{
    public partial class Order
    {
        public string Id { get; set; }
        public string Status { get; set; }

        public virtual Client Client { get; set; }
    }
}
