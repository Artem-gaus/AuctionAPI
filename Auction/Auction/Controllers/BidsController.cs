using BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Auction.Controllers
{
    [RoutePrefix("api/bids")]
    public class BidsController : ApiController
    {
        public BidsController()
        {

        }
        //[Route("{id:int}")]
        //[HttpGet]
        //public BidDTO Get(int id)
        //{ }
        [HttpPost]
        public void Add(BidDTO bidDTO)
        { }
        [HttpPut]
        public void Update(BidDTO bidDTO)
        { }
        [HttpDelete]
        public void Delete(BidDTO bidDTO)
        { }
    }
}
