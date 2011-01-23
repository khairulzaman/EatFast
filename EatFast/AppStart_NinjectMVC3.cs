using System.Web.Mvc;
using Ninject;
using Ninject.Mvc3;
using EatFast.Models.Abstract;
using EatFast.Models.Concrete;

[assembly: WebActivator.PreApplicationStartMethod(typeof(EatFast.AppStart_NinjectMVC3), "Start")]

namespace EatFast {
    public static class AppStart_NinjectMVC3 {
        public static void RegisterServices(IKernel kernel) {
            kernel.Bind<IRestaurantRepository>().To<LinqToSqlRestaurantsRepository>();
        }

        public static void Start() {
            // Create Ninject DI Kernel 
            IKernel kernel = new StandardKernel();

            // Register services with our Ninject DI Container
            RegisterServices(kernel);

            // Tell ASP.NET MVC 3 to use our Ninject DI Container 
            DependencyResolver.SetResolver(new NinjectServiceLocator(kernel));
        }
    }
}
