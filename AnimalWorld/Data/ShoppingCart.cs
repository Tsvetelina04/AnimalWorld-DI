using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalWorld.Data
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public  Client Clients { get; set; }

        public int ItemId { get; set; }
        public Item Items { get; set; }

        public int Quantity { get; set; }

       
        public DateTime RegisterOn { get; set; }
    }
}
