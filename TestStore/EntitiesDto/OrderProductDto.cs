using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestStore.EntitiesDto
{
    public class OrderProductDto
    {
        #nullable enable
        public string? Id { get; set; }

        public string? Img { get; set; }
        #nullable disable
        public string CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Pieces { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        public string OrderId { get; set; }
    }
}
