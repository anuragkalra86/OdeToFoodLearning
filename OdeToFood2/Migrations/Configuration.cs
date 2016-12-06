namespace OdeToFood2.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood2.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OdeToFood2.Models.OdeToFoodDb context)
        {
            context.Restaurants.AddOrUpdate(r => r.Name,
                            new Restaurant
                            {
                                Name = "FirstRest",
                                City = "Columbus",
                                Country = "USA",
                                Reviews = new List<RestaurantReview>
                                             {
                                     new RestaurantReview
                                     {
                                         ReviewerName = "MyName",
                                         Body = "Good food",
                                         Rating = 7
                                     }
                                             }
                            }

                            );
        }
    }
}
