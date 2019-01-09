using BusinessLogic.Interfaces;
using Auction.Controllers;
using NUnit.Framework;
using System.Web.Http;
using BusinessLogic.DTO;
using System.Web.Http.Results;
using FluentAssertions;

namespace Auction.Tests.Controllers.Tests
{
    [TestFixture]
    class CustomersControllerTests
    {
        ICustomerService service;
        CustomersController controller;
        public CustomersControllerTests()
        {
            service = new CustomerServiceFake();
            controller = new CustomersController(service);
        }
        #region Get method
        [Test]
        public void Get_WhenCalled_OkResult()
        {
            IHttpActionResult actionResult = controller.Get(1);
            var posResponse = actionResult as OkNegotiatedContentResult<CustomerDTO>;
            Assert.IsNotNull(posResponse);
        }
        [Test]
        public void Get_UnknownIdPassed_NotFoundResult()
        {
            IHttpActionResult actionResult = controller.Get(100500);
            var notFoundResult = actionResult as NotFoundResult;

            Assert.IsNotNull(notFoundResult);
        }
        [Test]
        public void Get_ExistingIdPassed_RightItem()
        {
            CustomerDTO expected = new CustomerDTO { Id = 1, Name = "Name1", Surname = "Surname1", Email = "his1@mail.com", Phone = 969699947, BankAccountNumber = 1234 };
            IHttpActionResult actionResult = controller.Get(1);
            var customer = actionResult as OkNegotiatedContentResult<CustomerDTO>;

            Assert.IsNotNull(customer);
            customer.Content.Should().BeEquivalentTo(expected);
        }
        #endregion
    }
}
