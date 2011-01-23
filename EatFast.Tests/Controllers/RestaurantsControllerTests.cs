using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Moq;
using EatFast.Models.Abstract;
using EatFast.Models.Entities;
using EatFast.Controllers;
using System.Web.Mvc;

namespace EatFast.Tests
{
    [TestFixture]
    public class RestaurantsControllerTests
    {
        static IRestaurantRepository MockRestaurantsRepository(params Restaurant[] rests)
        {
            var mockRestaurantsRepos = new Mock<IRestaurantRepository>();
            mockRestaurantsRepos.Setup(x => x.Restaurants).Returns(rests.AsQueryable());
            return mockRestaurantsRepos.Object;
        }

        [Test]
        public void Index_Should_Return_List_Of_Restaurants()
        {
            IRestaurantRepository repository = MockRestaurantsRepository(
                new Restaurant { Name = "Samurai Burgers Inc", IsActive = true },
                new Restaurant { Name = "Fried Chicken Kitchen", IsActive = true }
                );

            RestaurantsController controller = new RestaurantsController(repository);

            var result = controller.Index();

            Assert.IsNotNull(result, "Didn't render view");

            var restaurants = (IList<Restaurant>)result.ViewData.Model;
            Assert.AreEqual(2, restaurants.Count, "Got wrong number of items");
            Assert.AreEqual("Samurai Burgers Inc", restaurants[0].Name);
            Assert.AreEqual("Fried Chicken Kitchen", restaurants[1].Name);
        }

        [Test]
        public void Details_Should_Return_Single_Restaurant_By_ID()
        {
            IRestaurantRepository repository = MockRestaurantsRepository(
                new Restaurant { RestaurantID = 1, Name = "Samurai Burgers Inc", IsActive = true },
                new Restaurant { RestaurantID = 2, Name = "Fried Chicken Kitchen", IsActive = true }
                );

            RestaurantsController controller = new RestaurantsController(repository);

            var result = controller.Details(1);
            Assert.IsNotNull(result, "Didn't render view");

            var restaurant = (Restaurant)((ViewResult)result).ViewData.Model;
            Assert.AreEqual("Samurai Burgers Inc", restaurant.Name);
        }
    }
}