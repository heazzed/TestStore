using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestStore.Entities
{
    public class Order
    {
        public string? Id { get; set; }

        public Product[] Products { get; set; }

        public Client Client { get; set; }

        public enum Status
        {
            Обрабатывается,
            Подтвержден,
            Выполнен,
            Отменен
        }
    }
}
