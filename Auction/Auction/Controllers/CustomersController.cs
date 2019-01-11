using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
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

        protected CustomActionResult ErrorResponse(HttpStatusCode statusCode, string message)
        {
            return new CustomActionResult(statusCode, message, Request);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var customerDTO = customerService.Get(id);
            if (customerDTO == null || customerDTO.Id == 0)
            {
                return ErrorResponse(HttpStatusCode.NotFound, "Does not exist customer with id " + id);
            }

            return Ok(customerDTO);
        }
        [HttpPost]
        public IHttpActionResult Add([FromBody] CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(HttpStatusCode.BadRequest, "Customer's model is not valid");

            customerService.Create(customerDTO);

            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update([FromBody] CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(HttpStatusCode.BadRequest, "Customer's model is not valid");

            CustomerDTO existsCustomer = customerService.Get(customerDTO.Id);
            if (existsCustomer == null)
                return ErrorResponse(HttpStatusCode.NotFound, "You can not update Customer, becouse does customer not exist");

            customerService.Update(customerDTO);
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete([FromBody] CustomerDTO customerDTO)
        {
            CustomerDTO existsCustomer = customerService.Get(customerDTO.Id);
            if (existsCustomer == null)
                return ErrorResponse(HttpStatusCode.NotFound, "You can not remove the buyer " + customerDTO.Name + ", becouse does customer not exist");

            customerService.Delete(customerDTO);

            return Ok();
        }
    }
}