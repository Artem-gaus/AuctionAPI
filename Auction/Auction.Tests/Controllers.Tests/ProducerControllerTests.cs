using System.Collections.Generic;
using System.Web.Http;
using Auction.Controllers;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces.IServices;
using Moq;
using NUnit.Framework;
using System.Web.Http.Results;
using FluentAssertions;

namespace Auction.Tests.Controllers.Tests
{
    [TestFixture]
    class ProducerControllerTests
    {
        #region GetAll Tests
        [Test]
        public void GetAll_EmptyTable_NotFoundResult()
        {
            var mock = new Mock<IProducerService>();
            mock.Setup(a => a.GetAll()).Returns((List<ProducerDTO>)null);
            ProducersController controller = new ProducersController(mock.Object);

            IHttpActionResult actionResult = controller.GetAll();
            var producers = actionResult as NotFoundResult;

            Assert.IsNotNull(producers);
        }
        [Test]
        public void GetAll_WhenCalled_AllItems()
        {
            var mock = new Mock<IProducerService>();
            mock.Setup(a => a.GetAll()).Returns(new List<ProducerDTO>());
            ProducersController controller = new ProducersController(mock.Object);

            IHttpActionResult actionResult = controller.GetAll();
            var producers = actionResult as OkNegotiatedContentResult<List<ProducerDTO>>;

            Assert.IsNotNull(producers);
            producers.Content.Should().BeEquivalentTo(new List<ProducerDTO>());
        }
        #endregion
        #region Get Tests
        [Test]
        public void Get_ExistingIdPassed_RightItem()
        {
            var mock = new Mock<IProducerService>();
            mock.Setup(a => a.Get(1)).Returns(new ProducerDTO() { Id = 1, Title = "Producer1", Description = "DescriptionForProducer1" });
            ProducersController controller = new ProducersController(mock.Object);
            ProducerDTO expected = new ProducerDTO() { Id = 1, Title = "Producer1", Description = "DescriptionForProducer1" };

            IHttpActionResult actionResult = controller.Get(1);
            var producer = actionResult as OkNegotiatedContentResult<ProducerDTO>;

            producer.Content.Should().BeEquivalentTo(expected);
        }
        [Test]
        public void Get_UnknownIdPassed_NotFoundResult()
        {
            var mock = new Mock<IProducerService>();
            mock.Setup(a => a.Get(100500)).Returns((ProducerDTO)null);
            ProducersController controller = new ProducersController(mock.Object);

            var actionResult = controller.Get(100500) as NotFoundResult;

            Assert.IsNotNull(actionResult);
        }
        #endregion
        #region Add Tests
        [Test]
        public void Add_CorrectModel_OkResult()
        {
            var mock = new Mock<IProducerService>();
            mock.Setup(a => a.Create(new ProducerDTO()));
            ProducersController controller = new ProducersController(mock.Object);
            ProducerDTO producerDTO = new ProducerDTO() { Id = 1, Title = "Producer1", Description = "DescriptionForProducer1" };

            IHttpActionResult actionResult = controller.Add(producerDTO) as OkResult;

            Assert.IsNotNull(actionResult);
        }
        [Test]
        public void Add_WrongModel_BadRequest()
        {
            var mock = new Mock<IProducerService>();
            mock.Setup(a => a.Create(new ProducerDTO()));
            ProducersController controller = new ProducersController(mock.Object);
            ProducerDTO producerDTO = new ProducerDTO();

            IHttpActionResult actionResult = controller.Add(producerDTO);
            var notFoundResult = actionResult as BadRequestResult;

            Assert.IsNotNull(notFoundResult);
        }
        #endregion
        #region Update Tests
        [Test]
        public void Update_WrongModel_BadRequest()
        {
            var mock = new Mock<IProducerService>();
            mock.Setup(a => a.Update(new ProducerDTO()));
            ProducersController controller = new ProducersController(mock.Object);
            ProducerDTO producerDTO = new ProducerDTO();

            IHttpActionResult actionResult = controller.Update(producerDTO);
            var notFoundResult = actionResult as BadRequestResult;

            Assert.IsNotNull(notFoundResult);
        }
        [Test]
        public void Update_CorrectModel_OkResult()
        {
            var mock = new Mock<IProducerService>();
            mock.Setup(a => a.Update(new ProducerDTO()));
            mock.Setup(ms => ms.Get(1)).Returns(new ProducerDTO());
            ProducersController controller = new ProducersController(mock.Object);
            ProducerDTO producerDTO = new ProducerDTO() { Id = 1, Title = "Producer1", Description = "DescriptionForProducer1" };

            IHttpActionResult actionResult = controller.Update(producerDTO);
            var okResult = actionResult as OkResult;

            Assert.IsNotNull(okResult);
        }
        [Test]
        public void Update_UnknownIdPassed_NotFound()
        {
            var mock = new Mock<IProducerService>();
            mock.Setup(a => a.Update(new ProducerDTO()));
            mock.Setup(ms => ms.Get(1)).Returns((ProducerDTO)null);
            ProducersController controller = new ProducersController(mock.Object);
            ProducerDTO producerDTO = new ProducerDTO() { Id = 1, Title = "Producer1", Description = "DescriptionForProducer1" };

            IHttpActionResult actionResult = controller.Update(producerDTO);
            var notFoundResult = actionResult as NotFoundResult;

            Assert.IsNotNull(notFoundResult);
        }
        #endregion
        #region Delete Tests
        [Test]
        public void Delete_UnknownModelPassed_NotFound()
        {
            var mock = new Mock<IProducerService>();
            mock.Setup(a => a.Delete(new ProducerDTO()));
            mock.Setup(ms => ms.Get(1)).Returns((ProducerDTO)null);
            ProducersController controller = new ProducersController(mock.Object);
            ProducerDTO producerDTO = new ProducerDTO() { Id = 1, Title = "Producer1", Description = "DescriptionForProducer1" };

            IHttpActionResult actionResult = controller.Delete(producerDTO);
            var notFoundResult = actionResult as NotFoundResult;

            Assert.IsNotNull(notFoundResult);
        }
        [Test]
        public void Delete_ExistingModelPassed_NotFound()
        {
            var mock = new Mock<IProducerService>();
            mock.Setup(a => a.Delete(new ProducerDTO()));
            mock.Setup(ms => ms.Get(1)).Returns(new ProducerDTO());
            ProducersController controller = new ProducersController(mock.Object);
            ProducerDTO producerDTO = new ProducerDTO() { Id = 1, Title = "Producer1", Description = "DescriptionForProducer1" };

            IHttpActionResult actionResult = controller.Delete(producerDTO);
            var okResult = actionResult as OkResult;

            Assert.IsNotNull(okResult);
        }
        #endregion
    }
}
