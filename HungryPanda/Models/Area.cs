using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HungryPanda.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public City City { get; set; } //Naviagtion prop

        public int CityId { get; set; } //foreign key
    }
}