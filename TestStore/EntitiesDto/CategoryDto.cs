using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestStore.EntitiesDto
{
    public class CategoryDto
    {
        #nullable enable
        public string? Id  { get; set; }

        public string? Img { get; set; }
        #nullable disable

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
