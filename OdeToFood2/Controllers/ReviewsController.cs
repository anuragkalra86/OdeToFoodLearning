using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood2.Models;

namespace OdeToFood2.Controllers
{
    public class ReviewsController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();
        // GET: Reviews
        public ActionResult Index([Bind(Prefix ="id")]int restaurantId = 0)
        {
            var restaurant = _db.Restaurants.Find(restaurantId);
            if (restaurant == null)
            {
                return new HttpNotFoundResult();
            } 
            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Create(int restaurantId = 0)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Reviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            return View(review);
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
