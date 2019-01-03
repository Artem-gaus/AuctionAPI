using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BusinessLogic.DTO;
using BusinessLogic.Interfaces.IServices;

namespace Auction.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly IProductSevice productSevice;

        public ProductsController(IProductSevice productSevice)
        {
            this.productSevice = productSevice;
        }
        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ProductDTO productDTO = productSevice.Get(id);
            if (productDTO == null)
                return NotFound();

            return Ok(productDTO);
        }
        [HttpPost]
        public IHttpActionResult Add(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            productSevice.Create(productDTO);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            ProductDTO existsProduct = productSevice.Get(productDTO.Id);
            if (existsProduct == null)
                return NotFound();

            productSevice.Update(productDTO);
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(ProductDTO productDTO)
        {
            ProductDTO existsProduct = productSevice.Get(productDTO.Id);
            if (existsProduct == null)
                return NotFound();

            productSevice.Delete(productDTO);
            return Ok();
        }
    }
}
