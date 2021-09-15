using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestStore.Entities
{
    public class Order
    {
#nullable enable
        public Guid? Id { get; set; }
#nullable disable

        public ICollection<OrderProduct> Products { get; set; }

        public Client Client { get; set; }

        public string Status { get; set; }
    }
}

