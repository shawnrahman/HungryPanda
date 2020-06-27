using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HungryPanda.Models
{
    
        public enum Gender
        {
            Male = 1,
            Female = 2,
            Other = 3
        }
        public class Admin
        {

            public int Id { get; set; }
            public string Name { get; set; }
            public Gender Gender { get; set; }
            public DateTime DOB { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string Password { get; set; }
            public string Phone { get; set; }
            public string Role { get; set; }

        }
}
