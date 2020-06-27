using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HungryPanda.Models;


namespace HungryPanda.ViewModels
{
    public class ResturantMenuViewModel
    {
        public IEnumerable<ResturantMenu> ResturantMenu { get; set; }
        public IEnumerable<ResturantMenuCategory> ResturantMenuCategories { get; set; }
    }
}