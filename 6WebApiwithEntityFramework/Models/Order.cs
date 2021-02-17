using System;
using System.Collections.Generic;

#nullable disable

namespace _6WebApiwithEntityFramework.Models
{
    public partial class Order
    {
        public DateTime? OrderDate { get; set; }
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }
    }
}
