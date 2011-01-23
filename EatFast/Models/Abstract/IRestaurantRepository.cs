using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EatFast.Models.Entities;

namespace EatFast.Models.Abstract
{
    public interface IRestaurantRepository
    {
        IQueryable<Restaurant> Restaurants { get; }
        Restaurant Save(Restaurant restaurant);
        void Delete(Restaurant restaurant);
    }
}
