using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using EatFast.Models.Abstract;
using EatFast.Models.Entities;
using Moq;

namespace EatFast.Tests.Abstract
{
    [TestFixture]
    public class IRestaurantsTests
    {
        [Test]
        public void Save_Should_Not_Fail()
        {
            Mock<IRestaurantRepository> repository = new Mock<IRestaurantRepository>();
            Restaurant newRestaurant = new Restaurant();

            repository.Setup(x => x.Save(newRestaurant)).Returns(newRestaurant);

            repository.Object.Save(newRestaurant);

            repository.Verify<Restaurant>(x => x.Save(newRestaurant), "Unable to save.");
        }

        [Test]
        public void Delete_Should_Not_Fail()
        {
            Mock<IRestaurantRepository> repository = new Mock<IRestaurantRepository>();
            Restaurant newRestaurant = new Restaurant();

            repository.Setup(x => x.Delete(newRestaurant));

            repository.Object.Delete(newRestaurant);

            repository.Verify(x => x.Delete(newRestaurant), "Unable to delete.");
        }
    }
}
