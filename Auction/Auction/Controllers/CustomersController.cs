using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

using BusinessLogic.DTO;
using BusinessLogic.Interfaces;

namespace Auction.Controllers
{
    [RoutePrefix("api")]
    public class CustomersController : ApiController
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [Route("customers/{id:int}")]
        [HttpGet]
        public CustomerDTO Get(int id)
        {
            var cDTO = customerService.Get(id);
            return cDTO;
        }
    }
}