using System;
namespace TestStore.Entities
{
    public class OrderProduct
    {
        public Order Order { get; set; }

        public string OrderId { get; set; }

        public Product Product { get; set; }

        public string ProductId { get; set; }
    }
}
