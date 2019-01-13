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
    [RoutePrefix("api/bids")]
    public class BidsController : ApiController
    {
        private readonly IBidService bidService;

        public BidsController(IBidService bidService)
        {
            this.bidService = bidService;
        }

        protected CustomActionResult ErrorResponse(HttpStatusCode statusCode, string message)
        {
            return new CustomActionResult(statusCode, message, Request);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            BidDTO bidDTO = bidService.Get(id);
            if (bidDTO == null || bidDTO.Id == 0)
                return ErrorResponse(HttpStatusCode.NotFound, "Bid does not exist.");

            return Ok(bidDTO);
        }
        [Route("customer/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetByCustomer(int id)
        {
            List<BidDTO> bidDTOs = bidService.GetBidsByCustomer(id);
            if (bidDTOs == null)
                return ErrorResponse(HttpStatusCode.NotFound, "This Customer have not Bids");

            return Ok(bidDTOs);
        }
        [HttpPost]
        public IHttpActionResult Add(BidDTO bidDTO)
        {
            if (!ModelState.IsValid || bidDTO.ProductId == 0 || bidDTO.CustomerId == 0)
                return ErrorResponse(HttpStatusCode.BadRequest, "Parameters are not correct.");

            try
            {
                bidService.Create(bidDTO);
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
        [HttpPut]
        public IHttpActionResult Update(BidDTO bidDTO)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(HttpStatusCode.BadRequest, "Parameters are not correct.");

            try
            {
                bidService.Update(bidDTO);
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
        public IHttpActionResult Delete(BidDTO bidDTO)
        {
            try
            {
                bidService.Delete(bidDTO);
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
