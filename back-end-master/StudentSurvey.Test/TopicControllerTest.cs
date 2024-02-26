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
    public class TopicControllerTest : BaseIntegrationTests
    {

        [TestMethod]
        public async Task When_AddTopic_ShouldAddTopic()
        {


            var AddTopic = new TopicModel
            {
               Topic="Car"
            };
            var result = await HttpClient.PostAsJsonAsync("api/Topic", AddTopic);
            //Assert
            result.EnsureSuccessStatusCode();
            var TopicIdfromresult = await result.Content.ReadAsStringAsync();
            TopicIdfromresult.Should().NotBeNullOrEmpty();
            var ResultofGetTopicByID = await HttpClient.GetAsync($"api/Topic/{TopicIdfromresult}");
            ResultofGetTopicByID.EnsureSuccessStatusCode();
            var TopicfromResults = await ResultofGetTopicByID.Content.ReadFromJsonAsync<Topics>();
            TopicfromResults.Should().NotBeNull();
            TopicfromResults.Id.ToString().Should().Be(TopicIdfromresult);

        }

        [TestMethod]
        public async Task When_UpdateTopic_ShouldChangeTopicData()
        {


            var AddTopic = new Topics
            {

                Topic = "Car"
            };
            var result = await HttpClient.PostAsJsonAsync("api/Topic", AddTopic);
            //Assert
            result.EnsureSuccessStatusCode();
            var TopicIdfromresult = await result.Content.ReadAsStringAsync();

            var expectedDataChangeTopic = "Food";
            var topic = new Topics
            {
                Id = Convert.ToInt32(TopicIdfromresult),
                Topic =expectedDataChangeTopic
            };
            var resultforUpdateTopic = await HttpClient.PutAsJsonAsync("api/Topic", topic);
            //Assert

            resultforUpdateTopic.EnsureSuccessStatusCode();

            var ResultofGetTopicByID = await HttpClient.GetAsync($"api/Topic/{TopicIdfromresult}");
            ResultofGetTopicByID.EnsureSuccessStatusCode();
            var TopicfromResults = await ResultofGetTopicByID.Content.ReadFromJsonAsync<Topics>();
            TopicfromResults.Should().NotBeNull();
            TopicfromResults.Id.ToString().Should().Be(TopicIdfromresult);
            TopicfromResults.Topic.Should().Be(expectedDataChangeTopic);


        }

        [TestMethod]
        public async Task When_GetAll_ShouldGiveOKResponse()
        {



            var response = await HttpClient.GetAsync("/api/Topic");

            response.EnsureSuccessStatusCode();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

    }
}