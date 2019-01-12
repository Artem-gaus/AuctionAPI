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

        protected CustomActionResult ErrorResponse(HttpStatusCode statusCode, string message)
        {
            return new CustomActionResult(statusCode, message, Request);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ProductDTO productDTO = productSevice.Get(id);
            if (productDTO == null || productDTO.Id == 0)
                return ErrorResponse(HttpStatusCode.NotFound, "Product does not exist.");

            return Ok(productDTO);
        }
        [Route("producer/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetByProducer(int id)
        {
            List<ProductDTO> productDTOs = productSevice.GetProductsByProducer(id);
            if (productDTOs == null || productDTOs.Count == 0)
                return ErrorResponse(HttpStatusCode.NotFound, "This Producer have not Products");

            return Ok(productDTOs);
        }
        [Route("category/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetByCategory(int id)
        {
            List<ProductDTO> productDTOs = productSevice.GetProductsByCategory(id);
            if (productDTOs == null || productDTOs.Count == 0)
                return ErrorResponse(HttpStatusCode.NotFound, "This Category have not Products");

            return Ok(productDTOs);
        }
        [HttpPost]
        public IHttpActionResult Add(ProductDTO productDTO)
        {
            if (!ModelState.IsValid || productDTO.ProducerId==0 || productDTO.ProductCategoryId==0 || productDTO.SellerId==0)
                return ErrorResponse(HttpStatusCode.BadRequest, "Parameters are not correct.");

            productSevice.Create(productDTO);
            try
            {
                productSevice.Create(productDTO);
            }
            catch (Exception ex)
            {
                return ErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(HttpStatusCode.BadRequest, "Parameters are not correct.");

            try
            {
                productSevice.Update(productDTO);
            }
            catch (ArgumentException arEx)
            {
                return ErrorResponse(HttpStatusCode.BadRequest, arEx.Message);
            }
            catch (Exception)
            {
                return ErrorResponse(HttpStatusCode.InternalServerError, "");
            }
            
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(ProductDTO productDTO)
        {
            try
            {
                productSevice.Delete(productDTO);
            }
            catch (ArgumentException arEx)
            {
                return ErrorResponse(HttpStatusCode.NotFound, arEx.Message);
            }
            catch (Exception)
            {
                return ErrorResponse(HttpStatusCode.InternalServerError, "");
            }

            return Ok();
        }
    }
}
