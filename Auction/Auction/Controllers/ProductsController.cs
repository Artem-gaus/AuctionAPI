using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BusinessLogic.DTO;

namespace Auction.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        public ProductsController()
        {

        }
        //[Route("{id:int}")]
        //[HttpGet]
        //public ProductDTO Get(int id)
        //{ }
        [HttpPost]
        public void Add(ProductDTO productDTO)
        { }
        [HttpPut]
        public void Update(ProductDTO productDTO)
        { }
        [HttpDelete]
        public void Delete(ProductDTO productDTO)
        { }
    }
}
