using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

using BusinessLogic.DTO;
using BusinessLogic.Interfaces.IServices;

namespace Auction.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    [RoutePrefix("api/producers")]
    public class ProducersController : ApiController
    {
        private readonly IProducerService producerService;

        public ProducersController(IProducerService producerService)
        {
            this.producerService = producerService;
        }

        protected CustomActionResult ErrorResponse(HttpStatusCode statusCode, string message)
        {
            return new CustomActionResult(statusCode, message, Request);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ProducerDTO producerDTO = producerService.Get(id);
            if (producerDTO == null)
                return ErrorResponse(HttpStatusCode.NotFound, "You can not get the producer, becouse does producer not exist");

            return Ok(producerDTO);
        }
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<ProducerDTO> producerDTOs = producerService.GetAll();
            if (producerDTOs == null)
                return ErrorResponse(HttpStatusCode.NotFound, "You can not get the producers, becouse does producers not exist");

            return Ok(producerDTOs);
        }
        [HttpPost]
        public IHttpActionResult Add(ProducerDTO producerDTO)
        {
            if (!ModelState.IsValid || producerDTO.Title == "" || producerDTO.Title == null)
                return ErrorResponse(HttpStatusCode.BadRequest, "Producer's model is not valid");

            producerService.Create(producerDTO);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(ProducerDTO producerDTO)
        {
            if (!ModelState.IsValid || producerDTO.Title == "" || producerDTO.Title == null)
                return ErrorResponse(HttpStatusCode.BadRequest, "Producer's model is not valid");

            try
            {
                producerService.Update(producerDTO);
            }
            catch (ArgumentException arEx)
            {
                return ErrorResponse(HttpStatusCode.NotFound, arEx.Message);
            }
            catch (Exception)
            {
                return ErrorResponse(HttpStatusCode.BadRequest, "");
            }

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(ProducerDTO producerDTO)
        {
            try
            {
                producerService.Delete(producerDTO);
            }
            catch (ArgumentException arEx)
            {
                return ErrorResponse(HttpStatusCode.NotFound, arEx.Message);
            }
            catch (Exception)
            {
                return ErrorResponse(HttpStatusCode.BadRequest, "");
            }

            return Ok();
        }
    }
}
