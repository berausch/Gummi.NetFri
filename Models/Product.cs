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
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        
        [Column(TypeName="Money")]
        public decimal Price { get; set; }

        public string Origin { get; set; }
    }
}
