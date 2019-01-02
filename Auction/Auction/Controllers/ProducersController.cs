using BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Auction.Controllers
{
    [RoutePrefix("api/producers")]
    public class ProducersController : ApiController
    {
        public ProducersController()
        {

        }
        //[Route("{id:int}")]
        //[HttpGet]
        //public ProducerDTO Get(int id)
        //{ }
        [HttpPost]
        public void Add(ProducerDTO producerDTO)
        { }
        [HttpPut]
        public void Update(ProducerDTO producerDTO)
        { }
        [HttpDelete]
        public void Delete(ProducerDTO producerDTO)
        { }
    }
}
