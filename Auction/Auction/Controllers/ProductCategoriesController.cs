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
    [RoutePrefix("api/categories")]
    public class ProductCategoriesController : ApiController
    {
        private readonly IProductCategoryService categoryService;

        public ProductCategoriesController(IProductCategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        protected CustomActionResult ErrorResponse(HttpStatusCode statusCode, string message)
        {
            return new CustomActionResult(statusCode, message, Request);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ProductCategoryDTO categoryDTO = categoryService.Get(id);
            if (categoryDTO == null)
                return ErrorResponse(HttpStatusCode.NotFound, "Product Category does not exist.");

            return Ok(categoryDTO);
        }
        [HttpGet]
        public IEnumerable<ProductCategoryDTO> GetAll()
        {
            IEnumerable<ProductCategoryDTO> categoryDTOs = categoryService.GetAll();

            return categoryDTOs;
        }
        [HttpPost]
        public IHttpActionResult Add(ProductCategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(HttpStatusCode.BadRequest, "Parameters are not correct.");

            try
            {
                categoryService.Create(categoryDTO);
            }
            catch (Exception ex)
            {
                return ErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(ProductCategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(HttpStatusCode.BadRequest, "Parameters are not correct.");

            try
            {
                categoryService.Update(categoryDTO);
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
        public IHttpActionResult Delete(ProductCategoryDTO categoryDTO)
        {
            try
            {
                categoryService.Delete(categoryDTO);
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
    }
}
