﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood2.Models;

namespace OdeToFood2.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();
        public ActionResult Index(string searchTerm = null)
        {
            var model = _db.Restaurants.OrderByDescending(
                r => r.Reviews.Average(review => review.Rating)
                )
                .Where(r => searchTerm==null || r.Name.StartsWith(searchTerm))
                .Select(r => new RestaurantListViewModel
                {
                    Id = r.Id,
                    City = r.City,
                    Country = r.Country,
                    Name = r.Name,
                    CountOfReviews = r.Reviews.Count,
                });

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}