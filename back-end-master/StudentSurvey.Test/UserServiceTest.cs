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
    public class UserServiceTest
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _mapperMock = new Mock<IMapper>();
        }

        [TestMethod]
        public void DeleteUser_ShouldDeleteUser_WhenUserExists()
        {
            //Arange
            var user = new User
            {
                Id = 1
            };
            _userRepositoryMock.Setup(r => r.GetById(user.Id)).Returns(user);
            var userRepository = _userRepositoryMock.Object;
            var mapper = _mapperMock.Object;
            var sut = new UserService(userRepository, mapper);

            //Act
            sut.DeleteUser(user.Id);

            //
            _userRepositoryMock.Verify(r => r.Delete(user), Times.Once);

        }
        [TestMethod]
        public void DeleteUser_ShouldNotDeleteUser_WhenUserDoesNotExists()
        {
            //Arange
            User user = null;
            _userRepositoryMock.Setup(r => r.GetById(It.IsAny<int>())).Returns(user);
            var userRepository = _userRepositoryMock.Object;
            var mapper = _mapperMock.Object;
            var sut = new UserService(userRepository, mapper);

            //Act
            sut.DeleteUser(1);

            //
            _userRepositoryMock.Verify(r => r.Delete(It.IsAny<User>()), Times.Never);

        }


    }
}