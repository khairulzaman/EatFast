using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EatFast.Models.Abstract;
using EatFast.Models.Entities;

namespace EatFast.Models.Concrete
{
    public class LinqToSqlRestaurantsRepository : IRestaurantRepository
    {
        EatFastDataContext dataContext;

        public LinqToSqlRestaurantsRepository()
        {
            dataContext = new EatFastDataContext();
        }

        public IQueryable<Restaurant> Restaurants
        {
            get { return dataContext.Restaurants.AsQueryable<Restaurant>(); }
        }

        public Restaurant Save(Restaurant restaurant)
        {
            if (restaurant.RestaurantID <= 0)
            {
                dataContext.Restaurants.InsertOnSubmit(restaurant);
            }
            else
            {
                dataContext.Restaurants.Attach(restaurant);
                dataContext.Refresh(System.Data.Linq.RefreshMode.KeepChanges, restaurant);
            }

            dataContext.SubmitChanges();

            return restaurant;
        }
    }
}