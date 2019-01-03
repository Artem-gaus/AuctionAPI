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
    [RoutePrefix("api/categories")]
    public class ProductCategoriesController : ApiController
    {
        private readonly IProductCategoryService categoryService;

        public ProductCategoriesController(IProductCategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ProductCategoryDTO categoryDTO = categoryService.Get(id);
            if (categoryDTO == null)
                return NotFound();

            return Ok(categoryDTO);
        }
        [HttpPost]
        public IHttpActionResult Add(ProductCategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            categoryService.Create(categoryDTO);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(ProductCategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            ProductCategoryDTO existsCategory = categoryService.Get(categoryDTO.Id);
            if (existsCategory == null)
                return NotFound();

            categoryService.Update(categoryDTO);
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(ProductCategoryDTO categoryDTO)
        {
            ProductCategoryDTO existsCategory = categoryService.Get(categoryDTO.Id);
            if (existsCategory == null)
                return NotFound();

            categoryService.Delete(categoryDTO);
            return Ok();
        }
    }
}
