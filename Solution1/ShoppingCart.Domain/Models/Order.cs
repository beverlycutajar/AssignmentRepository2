using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Domain.Models
{
    public class Order
    {
        public int Id { set; get; }
        public Guid productId { get; set; }
        public int quantity { get; set; }
    }
}
