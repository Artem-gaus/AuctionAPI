using BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Auction.Controllers
{
    [RoutePrefix("api/categories")]
    public class ProductCategoriesController : ApiController
    {
        public ProductCategoriesController()
        {

        }
        //[Route("{id:int}")]
        //[HttpGet]
        //public ProductCategoryDTO Get(int id)
        //{ }
        [HttpPost]
        public void Add(ProductCategoryDTO categoryDTO)
        { }
        [HttpPut]
        public void Update(ProductCategoryDTO categoryDTO)
        { }
        [HttpDelete]
        public void Delete(ProductCategoryDTO categoryDTO)
        { }
    }
}
