using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestStore.Entities
{
    public class Product
    {
#nullable enable
        public Guid? Id { get; set; }

        public string? Img { get; set; }

        public Guid? CategoryId { get; set; }
#nullable disable
        public Category Category { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Pieces { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Price { get; set; }
    }
}
