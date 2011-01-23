using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EatFast.Models.Abstract;
using EatFast.Models.Entities;
using EatFast.Helpers;

namespace EatFast.Controllers
{
    public class RestaurantsController : Controller
    {

        IRestaurantRepository _repository;

        public RestaurantsController(IRestaurantRepository repository)
        {
            _repository = repository;
        }
        

        //
        // GET: /Restaurants/

        public ViewResult Index()
        {
            var restaurants = _repository.Restaurants.ToList();
            return View(restaurants);
        }

        public ActionResult Details(int id = 0)
        {
            if (id > 0)
            {
                var restaurant = _repository.Restaurants.First(x => x.RestaurantID == id);
                return View(restaurant);
            }

            else
            {
                ViewBag.Message = "No such entry.";
                return RedirectToAction("Index");
            }
        }

        public ActionResult Create()
        {
            return RedirectToAction("Edit");
        }

        public ActionResult Edit(int id = 0)
        {
            Restaurant restaurant;

            if (id > 0)
            {
                restaurant = _repository.Restaurants.First(x => x.RestaurantID == id);
            }

            else
            {
                restaurant = new Restaurant();
            }

            return View(restaurant);
        }

        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Save(restaurant);
                    ViewBag.Message = "New restaurant " + restaurant.Name + " was added to the database.";
                    return RedirectToAction("Index");
                }

                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                ViewBag.Message = "Data could not be saved. Please try again later.";
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id = 0)
        {
            try
            {
                if (id > 0)
                {
                    var restaurantDelete = _repository.Restaurants.First(x => x.RestaurantID == id);
                    _repository.Delete(restaurantDelete);
                    ViewBag.Message = "Delete of '" + restaurantDelete.Name + "' successful.";
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                ViewBag.Message = "Unable to delete. Please try again later.";
            }
            
            return RedirectToAction("Index");
        }
    }
}
