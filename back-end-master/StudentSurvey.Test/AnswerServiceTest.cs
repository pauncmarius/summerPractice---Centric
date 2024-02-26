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
    public class AnswerServiceTest
    {
        private Mock<IAnswersRepository> _answerRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _answerRepositoryMock = new Mock<IAnswersRepository>();
            _mapperMock = new Mock<IMapper>();
        }

        [TestMethod]
        public void DeleteAnswwer_ShouldDeleteAnswer_WhenAnswerExists()
        {
            //Arange
            var answer = new Answers
            {
                Id = 1
            };
            _answerRepositoryMock.Setup(r => r.GetById(answer.Id)).Returns(answer);
            var answerRepository = _answerRepositoryMock.Object;
            var mapper = _mapperMock.Object;
            var sut = new AnswerService(answerRepository, mapper);

            //Act
            sut.DeleteAnswer(answer.Id);

            //
            _answerRepositoryMock.Verify(r => r.Delete(answer), Times.Once);

        }
        [TestMethod]
        public void DeleteAnswer_ShouldNotDeleteAnswer_WhenAnswerDoesNotExists()
        {
            //Arange
            Answers answer = null;
            _answerRepositoryMock.Setup(r => r.GetById(It.IsAny<int>())).Returns(answer);
            var answerRepository = _answerRepositoryMock.Object;
            var mapper = _mapperMock.Object;
            var sut = new AnswerService(answerRepository, mapper);

            //Act
            sut.DeleteAnswer(1);

            //
            _answerRepositoryMock.Verify(r => r.Delete(It.IsAny<Answers>()), Times.Never);

        }


    }
}