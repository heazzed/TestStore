using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestStore.Entities
{
    public class Category
    {
        public string? Id  { get; set; }

        public string? Img { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
