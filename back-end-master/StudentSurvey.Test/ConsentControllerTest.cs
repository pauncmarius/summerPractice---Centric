using System;
using System.Collections.Generic;
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
    public class ConsentControllerTest : BaseIntegrationTests
    {

        [TestMethod]
        public async Task When_AddConsent_ShouldAddConsent()
        {
           var Adduser = new UserModel
            {
                Username = "sadfaf",
                Email = "alex@gmail.com",
                FirstName = "Alexandru",
                Hashed_Password = "123456",
                IsAdmin = true,
                LastName = "Bujor",
                PhoneNumber = "0771398991"
            };
            var resultss = await HttpClient.PostAsJsonAsync("api/User", Adduser);
            resultss.EnsureSuccessStatusCode();
            var UserTypeIdFromResult = await resultss.Content.ReadAsStringAsync();
            var AddTopic = new TopicModel
            {
                Topic="Food"
            };
            var resultTopic = await HttpClient.PostAsJsonAsync("api/Topic", AddTopic);


            resultTopic.EnsureSuccessStatusCode();
            var TopicTypeIdFromResult = await resultTopic.Content.ReadAsStringAsync();
            
            var Addsurvey = new SurveyModel
            {
                IDTopic = Convert.ToInt32(TopicTypeIdFromResult),
                Name = "Name",
                Description = "Descriere2",
                Opening_Time = DateTime.Now.AddMinutes(1),
                Closing_Time = DateTime.Now.AddMinutes(2),
                Created_By = "Alexandru2",
                Modified_By = "Marius2"

            };
            var resultsurvey = await HttpClient.PostAsJsonAsync("api/Survey", Addsurvey);
            //Assert
            resultsurvey.EnsureSuccessStatusCode();
            var surveyIdfromresult = await resultsurvey.Content.ReadAsStringAsync();
            var Addconsent = new ConsentModel
            {
                UserID = Convert.ToInt32(UserTypeIdFromResult),
                SurveyID = Convert.ToInt32(surveyIdfromresult),
                ExpirationDate = DateTime.Now.AddMonths(36),
                Agree=true

            };
            var result = await HttpClient.PostAsJsonAsync("api/Consent", Addconsent);
            //Assert
            result.EnsureSuccessStatusCode();
            var ConsentIdfromresult = await result.Content.ReadAsStringAsync();
            ConsentIdfromresult.Should().NotBeNullOrEmpty();
            var ResultofGetConsentByID = await HttpClient.GetAsync($"api/Consent/{ConsentIdfromresult}");
            ResultofGetConsentByID.EnsureSuccessStatusCode();
            var ConsentfromResults = await ResultofGetConsentByID.Content.ReadFromJsonAsync<Consent>();
            ConsentfromResults.Should().NotBeNull();
            ConsentfromResults.Id.ToString().Should().Be(ConsentIdfromresult);

        }

         [TestMethod]
         public async Task When_UpdateConsent_ShouldChangeConsentData()
         {


             var Adduser = new UserModel
             {
                 Username = "sadfaf",
                 Email = "alex@gmail.com",
                 FirstName = "Alexandru",
                 Hashed_Password = "123456",
                 IsAdmin = true,
                 LastName = "Bujor",
                 PhoneNumber = "0771398991"
             };
             var resultss = await HttpClient.PostAsJsonAsync("api/User", Adduser);
             resultss.EnsureSuccessStatusCode();
             var UserTypeIdFromResult = await resultss.Content.ReadAsStringAsync();
             var AddTopic = new TopicModel
             {
                 Topic="Food"
             };
             var resultTopic = await HttpClient.PostAsJsonAsync("api/Topic", AddTopic);


             resultTopic.EnsureSuccessStatusCode();
             var TopicTypeIdFromResult = await resultTopic.Content.ReadAsStringAsync();

             var Addsurvey = new SurveyModel
             {
                 IDTopic = Convert.ToInt32(TopicTypeIdFromResult),
                 Name = "Name",
                 Description = "Descriere2",
                 Opening_Time = DateTime.Now.AddMinutes(1),
                 Closing_Time = DateTime.Now.AddMinutes(2),
                 Created_By = "Alexandru2",
                 Modified_By = "Marius2"

             };
             var resultsurvey = await HttpClient.PostAsJsonAsync("api/Survey", Addsurvey);
             //Assert
             resultsurvey.EnsureSuccessStatusCode();
             var surveyIdfromresult = await resultsurvey.Content.ReadAsStringAsync();
             var Addconsent = new ConsentModel
             {
                 UserID = Convert.ToInt32(UserTypeIdFromResult),
                 SurveyID = Convert.ToInt32(surveyIdfromresult),
                 ExpirationDate = DateTime.Now.AddMonths(36),
                 Agree=true

             };
             var result = await HttpClient.PostAsJsonAsync("api/Consent", Addconsent);
            //Assert
            result.EnsureSuccessStatusCode();
             var ConsentIdfromresult = await result.Content.ReadAsStringAsync();

             var expectedDataChangeConsent = false;
             var consent = new Consent
             {
                 Id = Convert.ToInt32(ConsentIdfromresult),
                 UserID = Convert.ToInt32(UserTypeIdFromResult),
                 SurveyID = Convert.ToInt32(surveyIdfromresult),
                 ExpirationDate = DateTime.Now.AddMonths(36),
                 Agree = expectedDataChangeConsent
             };
             var resultforUpdateConsent = await HttpClient.PutAsJsonAsync("api/Consent", consent);
             //Assert

             resultforUpdateConsent.EnsureSuccessStatusCode();

             var ResultofGetConsentByID = await HttpClient.GetAsync($"api/Consent/{ConsentIdfromresult}");
             ResultofGetConsentByID.EnsureSuccessStatusCode();
             var ConsentfromResults = await ResultofGetConsentByID.Content.ReadFromJsonAsync<Consent>();
             ConsentfromResults.Should().NotBeNull();
             ConsentfromResults.Id.ToString().Should().Be(ConsentIdfromresult);
             ConsentfromResults.Agree.Should().Be(expectedDataChangeConsent);


         }

        [TestMethod]
        public async Task When_GetAll_ShouldGiveOKResponse()
        {



            var response = await HttpClient.GetAsync("/api/Consent");

            response.EnsureSuccessStatusCode();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

    }
}