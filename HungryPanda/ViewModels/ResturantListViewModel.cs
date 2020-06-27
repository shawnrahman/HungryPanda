using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HungryPanda.Models;

namespace HungryPanda.ViewModels
{
    public class ResturantListViewModel
    {
        public IEnumerable<ResturantOwner> ResturantOwners { get; set; }
    }
}