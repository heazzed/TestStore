using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestStore.EntitiesDto
{
    public class ProductDto
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
    }
}
