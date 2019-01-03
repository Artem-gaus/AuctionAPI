using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

using BusinessLogic.DTO;
using BusinessLogic.Interfaces;

namespace Auction.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var customerDTO = customerService.Get(id);
            if (customerDTO == null || customerDTO.Id == 0)
                return NotFound();

            return Ok(customerDTO);
        }
        [HttpPost]
        public IHttpActionResult Add([FromBody] CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            customerService.Create(customerDTO);

            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update([FromBody] CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CustomerDTO existsCustomer = customerService.Get(customerDTO.Id);
            if (existsCustomer == null)
                return NotFound();

            customerService.Update(customerDTO);
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete([FromBody] CustomerDTO customerDTO)
        {
            CustomerDTO existsCustomer = customerService.Get(customerDTO.Id);
            if (existsCustomer == null)
                return NotFound();

            customerService.Delete(customerDTO);

            return Ok();
        }
    }
}