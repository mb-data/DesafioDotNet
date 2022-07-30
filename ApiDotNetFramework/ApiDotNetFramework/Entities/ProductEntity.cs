using System;
using System.ComponentModel.DataAnnotations;

namespace ApiDotNetFramework.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "the field name missing.")]
        public string Name { get; set; }
        public string Brand { get; set; }
        [Required(ErrorMessage = "the filed price missing.")]
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ProductEntity()
        {

        }

        public ProductEntity(string name, string brand, double price)
        {
            Name = name;
            Brand = brand;
            Price = price;
        }
        
    }
}