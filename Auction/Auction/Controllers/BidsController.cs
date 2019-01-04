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
        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            BidDTO bidDTO = bidService.Get(id);
            if (bidDTO == null || bidDTO.Id == 0)
                return NotFound();

            return Ok(bidDTO);
        }
        [Route("customer/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetByCustomer(int id)
        {
            List<BidDTO> bidDTOs = bidService.GetBidsByCustomer(id);
            if (bidDTOs == null)
                return NotFound();

            return Ok(bidDTOs);
        }
        [HttpPost]
        public IHttpActionResult Add(BidDTO bidDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bidService.Create(bidDTO);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(BidDTO bidDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            BidDTO existsBid = bidService.Get(bidDTO.Id);
            if (existsBid == null)
                return NotFound();

            bidService.Update(bidDTO);
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(BidDTO bidDTO)
        {
            BidDTO existsBid = bidService.Get(bidDTO.Id);
            if (existsBid == null)
                return NotFound();

            bidService.Delete(bidDTO);
            return Ok();
        }
    }
}
