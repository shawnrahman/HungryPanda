using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HungryPanda.Models
{
    public class ResturantMenu
    {
        public int Id { get; set; }
        public string FoodItem { get; set; }
        public float Price { get; set; }
        public string Ratio { get; set; }

        public ResturantMenuCategory ResturantMenuCategory { get; set; }  //nav property
        public int ResturantMenuCategoryId { get; set; }// foreign keypublic ResturantMenuCategory ResturantMenuCategory { get; set; }  //nav property

        public ResturantOwner ResturantOwner { get; set; }  //nav property
        public int ResturantOwnerId { get; set; }// foreign key




    }
}