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
    public class TopicServiceTest
    {
        private Mock<ITopicsRepository> _topicRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _topicRepositoryMock = new Mock<ITopicsRepository>();
            _mapperMock = new Mock<IMapper>();
        }

        [TestMethod]
        public void DeleteTopic_ShouldDeleteTopic_WhenTopicExists()
        {
            //Arange
            var topic = new Topics
            {
                Id = 1
            };
            _topicRepositoryMock.Setup(r => r.GetById(topic.Id)).Returns(topic);
            var topicRepository = _topicRepositoryMock.Object;
            var mapper = _mapperMock.Object;
            var sut = new TopicService(topicRepository, mapper);

            //Act
            sut.DeleteTopic(topic.Id);

            //
            _topicRepositoryMock.Verify(r => r.Delete(topic), Times.Once);

        }
        [TestMethod]
        public void DeleteUser_ShouldNotDeleteUser_WhenUserDoesNotExists()
        {
            //Arange
            Topics topic = null;
            _topicRepositoryMock.Setup(r => r.GetById(It.IsAny<int>())).Returns(topic);
            var topicRepository = _topicRepositoryMock.Object;
            var mapper = _mapperMock.Object;
            var sut = new TopicService(topicRepository, mapper);

            //Act
            sut.DeleteTopic(1);

            //
            _topicRepositoryMock.Verify(r => r.Delete(It.IsAny<Topics>()), Times.Never);

        }


    }
}