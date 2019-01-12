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

        protected CustomActionResult ErrorResponse(HttpStatusCode statusCode, string message)
        {
            return new CustomActionResult(statusCode, message, Request);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            SellerDTO sellerDTO = sellerService.Get(id);
            if (sellerDTO == null)
                return ErrorResponse(HttpStatusCode.NotFound, "Seller does not exist.");

            return Ok(sellerDTO);
        }
        [HttpPost]
        public IHttpActionResult Add(SellerDTO sellerDTO)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(HttpStatusCode.BadRequest, "Parameters are not correct.");

            try
            {
                sellerService.Create(sellerDTO);
            }
            catch (Exception ex)
            {
                return ErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(SellerDTO sellerDTO)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(HttpStatusCode.BadRequest, "Parameters are not correct.");

            try
            {
                sellerService.Update(sellerDTO);
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
        public IHttpActionResult Delete(SellerDTO sellerDTO)
        {
            try
            {
                sellerService.Delete(sellerDTO);
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
    }
}
