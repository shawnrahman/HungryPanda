using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HungryPanda.Models
{
    public class Cuisine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ResturantOwner ResturantOwner { get; set; } //Navigation prop    
        public int ResturantOwnerId { get; set; } //foreign key
    }
}