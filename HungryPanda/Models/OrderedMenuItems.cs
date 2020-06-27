using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HungryPanda.Models
{
    public class OrderedMenuItems
    {

        public int Id { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }

        public Order Order { get; set; } // anvigation property
        public int OrderId { get; set; } // foreign key 

        public ResturantMenu ResturantMenu { get; set; } // anvigation property
        public int ResturantMenuId { get; set; } // foreign key 
    }
}