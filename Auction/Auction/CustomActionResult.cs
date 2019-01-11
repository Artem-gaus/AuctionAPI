using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Auction
{
    public class CustomActionResult : IHttpActionResult
    {
        public CustomActionResult(HttpStatusCode httpStatus, string message, HttpRequestMessage request)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            Message = message;
            Request = request;
            statusCode = httpStatus;
        }

        public string Message { get; private set; }
        public HttpRequestMessage Request { get; private set; }
        public HttpStatusCode statusCode { get; private set; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }
        public HttpResponseMessage Execute()
        {
            HttpResponseMessage response = new HttpResponseMessage(statusCode);
            response.Content = new StringContent(Message);
            response.RequestMessage = Request;
            return response;
        }
    }
}