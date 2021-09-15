using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestStore.Entities
{
    [Keyless]
    public class OrderProduct
    {
#nullable enable
        public Guid? ProductId { get; set; }

        public Guid? OrderId { get; set; }

#nullable disable

        public Order Order { get; set; }

        public Product Product { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Pieces { get; set; }
    }
}