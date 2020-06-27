using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HungryPanda.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ResturantOwner> ResturantOwners { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<ResturantMenuCategory> ResturantMenuCategories { get; set; }
        public DbSet<ResturantMenu> ResturantMenus { get; set; }
        public DbSet<DeliveryReview> DeliveryReviews{ get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<OrderedMenuItems> OrderedMenuItems{ get; set; }
        public DbSet<ResturantReview> ResturantReviews{ get; set; }
        public DbSet<Review> Reviews{ get; set; }


    }
}
