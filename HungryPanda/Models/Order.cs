using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HungryPanda.Models
{
    public enum OrderStatus
    {

        Processing = 1,
        Accepted = 2,
        Delivered = 3

    }

    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public String ResturantName { get; set; }


        public Customer Customer { get; set; }// anvigation property
        public int CustomerId { get; set; }// foreign key


        public Review Review { get; set; } // anvigation property
        public int? ReviewId { get; set; } // foreign key 
    }
}