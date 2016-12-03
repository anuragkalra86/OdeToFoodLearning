using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OdeToFood2.Models
{
    public class OdeToFoodDb : DbContext
    {
        public OdeToFoodDb() : base("Name=DefaultConnection")
        {
            
        } 
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }
    }
}