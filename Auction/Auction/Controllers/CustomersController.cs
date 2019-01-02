using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

using BusinessLogic.DTO;
using BusinessLogic.Interfaces;

namespace Auction.Controllers
{
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
        public CustomerDTO Get(int id)
        {
            var cDTO = customerService.Get(id);
            return cDTO;
        }
        [HttpPost]
        public void Add(CustomerDTO customerDTO)
        {
            customerService.Create(customerDTO);
        }
        [HttpPut]
        public void Update(CustomerDTO customerDTO)
        {
            customerService.Update(customerDTO);
        }
        [HttpDelete]
        public void Delete(CustomerDTO customerDTO)
        {
            customerService.Delete(customerDTO);
        }
    }
}