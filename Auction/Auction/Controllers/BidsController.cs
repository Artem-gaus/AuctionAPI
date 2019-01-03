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
