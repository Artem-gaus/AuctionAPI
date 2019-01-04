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
    [RoutePrefix("api/sellers")]
    public class SellersController : ApiController
    {
        private readonly ISellerService sellerService;

        public SellersController(ISellerService sellerService)
        {
            this.sellerService = sellerService;
        }
        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            SellerDTO sellerDTO = sellerService.Get(id);
            if (sellerDTO == null)
                return NotFound();

            return Ok(sellerDTO);
        }
        [HttpPost]
        public IHttpActionResult Add(SellerDTO sellerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            sellerService.Create(sellerDTO);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(SellerDTO sellerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            SellerDTO existsSeller = sellerService.Get(sellerDTO.Id);
            if (existsSeller == null)
                return NotFound();

            sellerService.Update(sellerDTO);
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(SellerDTO sellerDTO)
        {
            SellerDTO existsSeller = sellerService.Get(sellerDTO.Id);
            if (existsSeller == null)
                return NotFound();

            sellerService.Delete(sellerDTO);
            return Ok();
        }
    }
}
