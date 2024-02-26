using AutoMapper;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyHotel.Domain.Entities;
using StudentSurvey.Business.Services;
using StudentSurvey.Business.Services.IServices;
using StudentSurvey.Domain.IRepositories;

namespace StudentSurvey.Test
{
    [TestClass]
    public class ConsentServiceTest
    {
        private Mock<IConsentRepository> _consentRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _consentRepositoryMock = new Mock<IConsentRepository>();
            _mapperMock = new Mock<IMapper>();
        }

        [TestMethod]
        public void DeleteConsent_ShouldDeleteConsent_WhenConsentExists()
        {
            //Arange
            var consent = new Consent
            {
                Id = 1
            };
            _consentRepositoryMock.Setup(r => r.GetById(consent.Id)).Returns(consent);
            var ConsentRepository = _consentRepositoryMock.Object;
            var mapper = _mapperMock.Object;
            var sut = new ConsentService(ConsentRepository, mapper);

            //Act
            sut.DeleteConsent(consent.Id);

            //
            _consentRepositoryMock.Verify(r => r.Delete(consent), Times.Once);

        }

        [TestMethod]
        public void DeleteConsent_ShouldNotDeleteConsent_WhenConsentDoesNotExists()
        {
            //Arange
            Consent consent = null;
            _consentRepositoryMock.Setup(r => r.GetById(It.IsAny<int>())).Returns(consent);


            var ConsentRepository = _consentRepositoryMock.Object;
            var mapper = _mapperMock.Object;
            var sut = new ConsentService(ConsentRepository, mapper);

            //Act
            sut.DeleteConsent(1);

            //
            _consentRepositoryMock.Verify(r => r.Delete(It.IsAny<Consent>()), Times.Never);

        }
    }

}
