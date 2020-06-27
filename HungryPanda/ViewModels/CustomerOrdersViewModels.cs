using HungryPanda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HungryPanda.ViewModels
{
    public class CustomerOrdersViewModels
    {
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<OrderedMenuItems> OrderedMenuItems { get; set; }
        public IEnumerable<ResturantOwner> ResturantOwner { get; set; }

    }
}