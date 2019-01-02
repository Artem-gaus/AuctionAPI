using BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Auction.Controllers
{
    [RoutePrefix("api/sellers")]
    public class SellersController : ApiController
    {
        public SellersController()
        {

        }
        //[Route("{id:int}")]
        //[HttpGet]
        //public SellerDTO Get(int id)
        //{ }
        [HttpPost]
        public void Add(SellerDTO sellerDTO)
        { }
        [HttpPut]
        public void Update(SellerDTO sellerDTO)
        { }
        [HttpDelete]
        public void Delete(SellerDTO sellerDTO)
        { }
    }
}
