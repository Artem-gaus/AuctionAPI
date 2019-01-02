using System.Web.Mvc;
using System.Web.Http;

using SimpleInjector;

using DataAccess;
using Auction.App_Start;
using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccess.Repositories;
using BusinessLogic.Interfaces;

namespace Auction
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();
            container.Register<ICustomerService, CustomerService>();
            container.Register<IUnitOfWork, UnitOfWork>();
            container.Register<IRepository<Customer>, Repository<Customer>>();
            container.Register<ICustomerRepository, CustomerRepository>();

            //container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
