using System.Web.Mvc;
using System.Web.Http;

using SimpleInjector;

using DataAccess;
using Auction.App_Start;
using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccess.Repositories;
using BusinessLogic.Interfaces;
using BusinessLogic.Interfaces.IServices;
using BusinessLogic.Interfaces.IRepositories;

namespace Auction
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();

            container.Register<ICustomerService, CustomerService>();
            container.Register<IBidService, BidService>();
            container.Register<IProducerService, ProducerService>();
            container.Register<IProductCategoryService, ProductCategoryService>();
            container.Register<IProductSevice, ProductService>();
            container.Register<ISellerService, SellerService>();

            container.Register<IUnitOfWork, UnitOfWork>();

            container.Register<IRepository<Customer>, Repository<Customer>>();
            container.Register<ICustomerRepository, CustomerRepository>();

            container.Register<IRepository<Bid>, Repository<Bid>>();
            container.Register<IBidRepository, BidRepository>();

            container.Register<IRepository<Producer>, Repository<Producer>>();
            container.Register<IProducerRepository, ProducerRepository>();

            container.Register<IRepository<ProductCategory>, Repository<ProductCategory>>();
            container.Register<IProductCategoryRepository, ProductCategoryRepository>();

            container.Register<IRepository<Product>, Repository<Product>>();
            container.Register<IProductRepository, ProductRepository>();

            container.Register<IRepository<Seller>, Repository<Seller>>();
            container.Register<ISellerRepository, SellerRepository>();

            //container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
