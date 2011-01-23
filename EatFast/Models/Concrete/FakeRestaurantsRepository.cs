using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EatFast.Models.Abstract;
using EatFast.Models.Entities;

namespace EatFast.Models.Concrete
{
    public class FakeRestaurantsRepository : IRestaurantRepository
    {
        private static IQueryable<Restaurant> fakeRestaurants = new List<Restaurant>
        {
            new Restaurant { Name = "Samurai Burgers", IsActive = true},
            new Restaurant { Name = "Carrot Waffles", IsActive = true},
            new Restaurant { Name = "Bacon of Narwhal", IsActive = true}
        }.AsQueryable();

        public IQueryable<Restaurant> Restaurants
        {
            get { return fakeRestaurants; }
        }


        public Restaurant Save(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }


        public void Delete(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }
    }
}