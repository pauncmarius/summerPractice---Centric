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
    public class Survey_AnswerServiceTest
    {
        private Mock<ISurvey_AnswersRepository> _surveyanswerRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _surveyanswerRepositoryMock = new Mock<ISurvey_AnswersRepository>();
            _mapperMock = new Mock<IMapper>();
        }

        [TestMethod]
        public void DeleteSurveyAnswwer_ShouldDeleteSurveyAnswer_WhenSurveyAnswerExists()
        {
            //Arange
            var survey_answer = new Survey_Answers
            {
                Id = 1
            };
            _surveyanswerRepositoryMock.Setup(r => r.GetById(survey_answer.Id)).Returns(survey_answer);
            var surveyanswerRepository = _surveyanswerRepositoryMock.Object;
            var mapper = _mapperMock.Object;
            var sut = new Survey_AnswerService(surveyanswerRepository, mapper);

            //Act
            sut.DeleteSurvey_Answer(survey_answer.Id);

            //
            _surveyanswerRepositoryMock.Verify(r => r.Delete(survey_answer), Times.Once);

        }
        [TestMethod]
        public void DeleteSurveyAnswer_ShouldNotDeleteSurveyAnswer_WhenSurveyAnswerDoesNotExists()
        {
            //Arange
            Survey_Answers survey_answer = null;
            _surveyanswerRepositoryMock.Setup(r => r.GetById(It.IsAny<int>())).Returns(survey_answer);
            var surveyanswerRepository = _surveyanswerRepositoryMock.Object;
            var mapper = _mapperMock.Object;
            var sut = new Survey_AnswerService(surveyanswerRepository, mapper);

            //Act
            sut.DeleteSurvey_Answer(1);

            //
            _surveyanswerRepositoryMock.Verify(r => r.Delete(It.IsAny<Survey_Answers>()), Times.Never);

        }


    }
}