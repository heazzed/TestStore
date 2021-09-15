using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestStore.EntitiesDto
{
    public class OrderDto
    {
#nullable enable
        public string? Id { get; set; }
#nullable disable

        public ICollection<OrderProductDto> Products { get; set; }

        public ClientDto Client { get; set; }

        public string Status { get; set; }

    }
}

