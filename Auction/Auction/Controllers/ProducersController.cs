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
    [RoutePrefix("api/producers")]
    public class ProducersController : ApiController
    {
        private readonly IProducerService producerService;

        public ProducersController(IProducerService producerService)
        {
            this.producerService = producerService;
        }
        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ProducerDTO producerDTO = producerService.Get(id);
            if (producerDTO == null)
                return NotFound();

            return Ok(producerDTO);
        }
        [HttpPost]
        public IHttpActionResult Add(ProducerDTO producerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            producerService.Create(producerDTO);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(ProducerDTO producerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            ProducerDTO existsProducer = producerService.Get(producerDTO.Id);
            if (existsProducer == null)
                return NotFound();

            producerService.Update(producerDTO);
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(ProducerDTO producerDTO)
        {
            ProducerDTO existsProducer = producerService.Get(producerDTO.Id);
            if (existsProducer == null)
                return NotFound();

            producerService.Delete(producerDTO);
            return Ok();
        }
    }
}
