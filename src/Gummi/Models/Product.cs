using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gummi.Models
{   
    [Table("Products")]
    public class Product
    {
        public Product()
        {
        }

        public Product(string name, decimal price, string origin, byte[] image)
        {
            Name = name;
            Price = price;
            Origin = origin;
            Image = image;
        }

        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        
        [Column(TypeName="Money")]
        public decimal Price { get; set; }

        public string Origin { get; set; }

        public byte[] Image { get; set; } 
    }
}
