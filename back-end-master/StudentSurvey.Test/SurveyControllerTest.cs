using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyHotel.Domain.Entities;
using StudentSurvey.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Test
{
    [TestClass]
    public class SurveyControllerTest : BaseIntegrationTests
    {

        [TestMethod]
        public async Task When_AddSurvey_ShouldAddUser()
        {


            var AddSurvey = new SurveyModel
            {
                IDTopic = 1,
                Name = "Car",
                Description = "Descriere",
                Opening_Time = DateTime.Now.AddMinutes(1),
                Closing_Time = DateTime.Now.AddMinutes(2),
                Created_By = "Alexandru",
                Modified_By = "Marius"

            };
            var result = await HttpClient.PostAsJsonAsync("api/Survey", AddSurvey);
            //Assert
            result.EnsureSuccessStatusCode();
            var surveyIdfromresult = await result.Content.ReadAsStringAsync();
            surveyIdfromresult.Should().NotBeNullOrEmpty();
            var ResultofGetSurveyByID = await HttpClient.GetAsync($"api/Survey/{surveyIdfromresult}");
            ResultofGetSurveyByID.EnsureSuccessStatusCode();
            var SurveyfromResults = await ResultofGetSurveyByID.Content.ReadFromJsonAsync<Survey>();
            SurveyfromResults.Should().NotBeNull();
            SurveyfromResults.Id.ToString().Should().Be(surveyIdfromresult);

        }

        [TestMethod]
        public async Task When_UpdateSurvey_ShouldChangesurveyData()
        {


            var Addsurvey = new Survey
            {
                IDTopic =99,
                Name = "Name",
                Description = "Descriere2",
                Opening_Time = DateTime.Now.AddMinutes(1),
                Closing_Time = DateTime.Now.AddMinutes(2),
                Created_By = "Alexandru2",
                Modified_By = "Marius2"

            };
            var result = await HttpClient.PostAsJsonAsync("api/Survey", Addsurvey);
            //Assert
            result.EnsureSuccessStatusCode();
            var surveyIdfromresult = await result.Content.ReadAsStringAsync();

            var expectedDataChangeSurvey = "Food";
            var survey = new Survey
            {
                Id = Convert.ToInt32(surveyIdfromresult),
                Name = expectedDataChangeSurvey,
                Description = "Descriere",
                Opening_Time = DateTime.Now.AddMinutes(1),
                Closing_Time = DateTime.Now.AddMinutes(2),
                Created_By = "Alexandru",
                Modified_By = "Marius"
            };
            var resultforUpdateSurvey = await HttpClient.PutAsJsonAsync("api/Survey", survey);
            //Assert

            resultforUpdateSurvey.EnsureSuccessStatusCode();

            var ResultofGetSurveyByID = await HttpClient.GetAsync($"api/Survey/{surveyIdfromresult}");
            ResultofGetSurveyByID.EnsureSuccessStatusCode();
            var SurveyfromResults = await ResultofGetSurveyByID.Content.ReadFromJsonAsync<Survey>();
            SurveyfromResults.Should().NotBeNull();
            SurveyfromResults.Id.ToString().Should().Be(surveyIdfromresult);
            SurveyfromResults.Name.Should().Be(expectedDataChangeSurvey);


        }

        [TestMethod]
        public async Task When_GetAll_ShouldGiveOKResponse()
        {



            var response = await HttpClient.GetAsync("/api/Survey");

            response.EnsureSuccessStatusCode();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
    }
}
