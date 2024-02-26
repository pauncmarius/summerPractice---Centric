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
    public class Survey_QuestionServiceTest
    {
        private Mock<ISurvey_QuestionsRepository> _surveyquestionRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _surveyquestionRepositoryMock = new Mock<ISurvey_QuestionsRepository>();
            _mapperMock = new Mock<IMapper>();
        }

        [TestMethod]
        public void DeleteSurveyQuestion_ShouldDeleteSurveyQuestion_WhenSurveyQuestionExists()
        {
            //Arange
            var survey_question = new Survey_Questions
            {
                Id = 1
            };
            _surveyquestionRepositoryMock.Setup(r => r.GetById(survey_question.Id)).Returns(survey_question);
            var surveyquestionRepository = _surveyquestionRepositoryMock.Object;
            var mapper = _mapperMock.Object;
            var sut = new Survey_QuestionService(surveyquestionRepository, mapper);

            //Act
            sut.DeleteSurvey_Question(survey_question.Id);

            //
            _surveyquestionRepositoryMock.Verify(r => r.Delete(survey_question), Times.Once);

        }
        [TestMethod]
        public void DeleteUser_ShouldNotDeleteUser_WhenUserDoesNotExists()
        {
            //Arange
            Survey_Questions survey_question = null;
            _surveyquestionRepositoryMock.Setup(r => r.GetById(It.IsAny<int>())).Returns(survey_question);
            var surveyquestionRepository = _surveyquestionRepositoryMock.Object;
            var mapper = _mapperMock.Object;
            var sut = new Survey_QuestionService(surveyquestionRepository, mapper);

            //Act
            sut.DeleteSurvey_Question(1);

            //
            _surveyquestionRepositoryMock.Verify(r => r.Delete(It.IsAny<Survey_Questions>()), Times.Never);

        }


    }
}