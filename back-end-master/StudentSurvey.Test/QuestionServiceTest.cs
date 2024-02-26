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
    public class QuestionServiceTest
    {
        private Mock<IQuestionsRepository> _questionRepositoryMock;
        private Mock<IQuestion_TypeRepository> _questionTypeRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _questionRepositoryMock = new Mock<IQuestionsRepository>();
            _questionTypeRepositoryMock=new Mock<IQuestion_TypeRepository>();
            _mapperMock = new Mock<IMapper>();
        }

        [TestMethod]
        public void DeleteQuestion_ShouldDeleteQuestion_WhenQuestionExists()
        {
            //Arange
            var question = new Questions
            {
                Id = 1
            };
            _questionRepositoryMock.Setup(r => r.GetById(question.Id)).Returns(question);
            var questionRepository = _questionRepositoryMock.Object;
            var questionTypeRepository = _questionTypeRepositoryMock.Object;
            var mapper = _mapperMock.Object;
            var sut = new QuestionService(questionRepository,questionTypeRepository, mapper);

            //Act
            sut.DeleteQuestion(question.Id);

            //
            _questionRepositoryMock.Verify(r => r.Delete(question), Times.Once);

        }
        [TestMethod]
        public void DeleteUser_ShouldNotDeleteUser_WhenUserDoesNotExists()
        {
            //Arange
            Questions question = null;
            _questionRepositoryMock.Setup(r => r.GetById(It.IsAny<int>())).Returns(question);
            var questionRepository = _questionRepositoryMock.Object;
            var questionTypeRepository = _questionTypeRepositoryMock.Object;
            var mapper = _mapperMock.Object;
            var sut = new QuestionService(questionRepository,questionTypeRepository, mapper);

            //Act
            sut.DeleteQuestion(1);

            //
            _questionRepositoryMock.Verify(r => r.Delete(It.IsAny<Questions>()), Times.Never);

        }


    }
}