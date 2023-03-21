using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalWorld.Data
{
    public class Item
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string ImageUrl { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ItemPrice { get; set; }
        
        public int Availability { get; set; }
        
        public int CategoryId { get; set; }
        public Category Categories { get; set; }

        public int PurposeId { get; set; }
        public Purpose Purposes { get; set; }
        public ICollection <ShoppingCart> ShoppingCarts  {get; set; }

        public DateTime RegisterOn { get; set; }
    }
}
