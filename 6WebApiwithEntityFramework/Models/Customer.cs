using System;
using System.Collections.Generic;

#nullable disable

namespace _6WebApiwithEntityFramework.Models
{
    public partial class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public int CustomerId { get; set; }
    }
}
