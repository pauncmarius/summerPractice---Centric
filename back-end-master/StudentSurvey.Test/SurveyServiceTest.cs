using AutoMapper;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyHotel.Domain.Entities;
using StudentSurvey.Business.Services;
using StudentSurvey.Domain.IRepositories;

namespace StudentSurvey.Test
{
    [TestClass]
    public class SurveyServiceTest
    {
        private Mock<ISurveyRepository> _surveyRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _surveyRepositoryMock = new Mock<ISurveyRepository>();
            _mapperMock = new Mock<IMapper>();
        }

        [TestMethod]
        public void DeleteSurvey_ShouldDeleteSurvey_WhenSurveyExists()
        {

            //Arange
            var survey = new Survey
            {
                Id = 1
            };
            _surveyRepositoryMock.Setup(r => r.GetById(survey.Id)).Returns(survey);
            var surveyRepository = _surveyRepositoryMock.Object;
            var mapper = _mapperMock.Object;
            var sut = new SurveyService(surveyRepository, mapper);

            //Act
            sut.DeleteSurvey(survey.Id);

            //
            _surveyRepositoryMock.Verify(r => r.Delete(survey), Times.Once);

        }
        [TestMethod]
        public void DeleteSurvey_ShouldNotDeleteSurvey_WhenSurveyDoesNotExists()
        {
            //Arange
            Survey survey = null;
            _surveyRepositoryMock.Setup(r => r.GetById(It.IsAny<int>())).Returns(survey);
            var surveyRepository = _surveyRepositoryMock.Object;
            var mapper = _mapperMock.Object;
            var sut = new SurveyService(surveyRepository, mapper);

            //Act
            sut.DeleteSurvey(1);

            //
            _surveyRepositoryMock.Verify(r => r.Delete(It.IsAny<Survey>()), Times.Never);

        }


    }
}