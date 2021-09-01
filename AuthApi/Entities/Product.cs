﻿using System;
using System.Collections.Generic;

#nullable disable

namespace TestStore.AuthApi.Entities
{
    public partial class Product
    {
        public string Id { get; set; }
        public string Img { get; set; }
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Pieces { get; set; }
        public decimal Price { get; set; }

        public virtual Category Category { get; set; }
    }
}
