using HungryPanda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HungryPanda.ViewModels
{
    public class CityAndAreaViewModel
    {
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<Area> Areas { get; set; }

    }
}