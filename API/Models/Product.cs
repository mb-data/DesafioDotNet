using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Product
    {
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Id { get; set; }

    }
}