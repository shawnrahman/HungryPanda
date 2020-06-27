using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HungryPanda.Models
{
    public enum ResturantStatus
    {
        Valid = 1,
        Probation = 2,
        Banned = 3
    }

    public class ResturantOwner
    {
        public int Id { get; set; }
        public string ResturantOwnerName { get; set; }
        public string ResturantName { get; set; }
        public DateTime JoinDate { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public ResturantStatus ResturantStatus { get; set; }


        public int? AreaId { get; set; }//foreign key
        public Area Area { get; set; } // Nav prop
        public string Role { get; set; }






    }
}