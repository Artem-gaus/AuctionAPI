using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

using BusinessLogic.DTO;
using BusinessLogic.Interfaces.IServices;

namespace Auction.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
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
        [Route("producer/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetByProducer(int id)
        {
            List<ProductDTO> productDTOs = productSevice.GetProductsByProducer(id);
            if (productDTOs == null)
                return NotFound();

            return Ok(productDTOs);
        }
        [Route("category/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetByCategory(int id)
        {
            List<ProductDTO> productDTOs = productSevice.GetProductsByCategory(id);
            if (productDTOs == null)
                return NotFound();

            return Ok(productDTOs);
        }
        [HttpPost]
        public IHttpActionResult Add(ProductDTO productDTO)
        {
            if (!ModelState.IsValid || productDTO.ProducerId==0 || productDTO.ProductCategoryId==0 || productDTO.SellerId==0)
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
