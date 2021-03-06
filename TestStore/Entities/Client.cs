using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestStore.Entities
{
    public class Client
    {
#nullable enable
        public Guid? OrderId { get; set; }

        public string? Email { get; set; }
#nullable disable

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }
        
        public string Phone { get; set; }
    }
}
