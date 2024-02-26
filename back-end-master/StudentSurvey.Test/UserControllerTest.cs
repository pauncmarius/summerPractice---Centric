using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyHotel.Domain.Entities;
using StudentSurvey.Business.Models;

namespace StudentSurvey.Test
{
    [TestClass]
    public class UserControllerTest : BaseIntegrationTests
    {

        [TestMethod]
        public async Task When_AddUser_ShouldAddUser()
        {


            var Adduser = new UserModel
            {
                Username = "Alex",
                Email = "alex@gmail.com",
                FirstName = "Alexandru",
                Hashed_Password = "123456",
                IsAdmin = true,
                LastName = "Bujor",
                PhoneNumber = "0771398991"
            };
            var result = await HttpClient.PostAsJsonAsync("api/User", Adduser);
            //Assert
            result.EnsureSuccessStatusCode();
            var userIdfromresult = await result.Content.ReadAsStringAsync();
            userIdfromresult.Should().NotBeNullOrEmpty();
            var ResultofGetUserByID = await HttpClient.GetAsync($"api/User/{userIdfromresult}");
            ResultofGetUserByID.EnsureSuccessStatusCode();
            var UserfromResults = await ResultofGetUserByID.Content.ReadFromJsonAsync<User>();
            UserfromResults.Should().NotBeNull();
            UserfromResults.Id.ToString().Should().Be(userIdfromresult);

        }

        [TestMethod]
        public async Task When_UpdateUser_ShouldChangeUserData()
        {


            var Adduser = new User
            {
                Username = "Vasilica",
                Email = "alex@gmail.com",
                FirstName = "Alexandru",
                Hashed_Password = "123456",
                IsAdmin = true,
                LastName = "Bujor",
                PhoneNumber = "0771398991"
            };
            var result = await HttpClient.PostAsJsonAsync("api/User", Adduser);
            //Assert
            result.EnsureSuccessStatusCode();
            var userIdfromresult = await result.Content.ReadAsStringAsync();

            var expectedDataChangeUser = "Vasilic";
            var user = new User
            {
                Id = Convert.ToInt32(userIdfromresult),
                Username = expectedDataChangeUser,
                Email = "alex@gmail.com",
                FirstName = "Alexandru",
                Hashed_Password = "123456",
                IsAdmin = true,
                LastName = "Bujor",
                PhoneNumber = "0771398991"
            };
            var resultforUpdateUser = await HttpClient.PutAsJsonAsync("api/User", user);
            //Assert

            resultforUpdateUser.EnsureSuccessStatusCode();

            var ResultofGetUserByID = await HttpClient.GetAsync($"api/User/{userIdfromresult}");
            ResultofGetUserByID.EnsureSuccessStatusCode();
            var UserfromResults = await ResultofGetUserByID.Content.ReadFromJsonAsync<User>();
            UserfromResults.Should().NotBeNull();
            UserfromResults.Id.ToString().Should().Be(userIdfromresult);
            UserfromResults.Username.Should().Be(expectedDataChangeUser);


        }

        [TestMethod]
        public async Task When_GetAll_ShouldGiveOKResponse()
        {



            var response = await HttpClient.GetAsync("/api/User");

            response.EnsureSuccessStatusCode();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }


    }
}