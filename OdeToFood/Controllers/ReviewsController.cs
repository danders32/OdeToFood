﻿using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {
        OdeToFoodDB _db = new OdeToFoodDB();

        public ActionResult Index([Bind(Prefix="id")]int restaurantID)
        {
            var restaurant = _db.Restaurants.Find(restaurantID);
            if (restaurant != null)
            {
                return View(restaurant);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create(int restaurantID)
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
                return RedirectToAction("Index", new { id = review.RestaurantID });
            }
            return View(review);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.Reviews.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantID });
            }
            return View(review);
            
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

    }
}
