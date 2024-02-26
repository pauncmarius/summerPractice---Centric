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
    public class Survey_AnswerControllerTest : BaseIntegrationTests
    {

        [TestMethod]
        public async Task When_AddSurvey_Answer_ShouldAddSurvey_Answer()
        {

            var AddTopic = new TopicModel
            {
                Topic = "Food"
            };
            var resultTopic = await HttpClient.PostAsJsonAsync("api/Topic", AddTopic);


            resultTopic.EnsureSuccessStatusCode();
            var TopicIdFromResult = await resultTopic.Content.ReadAsStringAsync();

            var Addsurvey = new SurveyModel
            {
                //IDTopic = Convert.ToInt32(TopicIdFromResult),
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
            var Question_Type = new QuestionTypeModel
            {
                QuestionType="Food"
            };
            var resultQuestionType = await HttpClient.PostAsJsonAsync("api/QuestionType", Question_Type);


            resultQuestionType.EnsureSuccessStatusCode();
            var QuestionTypeIdFromResult = await resultQuestionType.Content.ReadAsStringAsync();

            var Question = new QuestionModel
            {
                Question = "Ce?",
                Question_TypeID = Convert.ToInt32(QuestionTypeIdFromResult)
            };
            var results = await HttpClient.PostAsJsonAsync("api/Question", Question);


            results.EnsureSuccessStatusCode();
            var QuestionIdFromResult = await results.Content.ReadAsStringAsync();
            var Addsurvey_Question = new Survey_QuestionModel
            {
                QuestionsID = Convert.ToInt32(QuestionIdFromResult),
                SurveyID = Convert.ToInt32(surveyIdfromresult)

            };
            var resultSurvey_Question = await HttpClient.PostAsJsonAsync("api/Survey_Question", Addsurvey_Question);
            //Assert
            resultSurvey_Question.EnsureSuccessStatusCode();

            var Survey_QuestionIdfromresult = await resultSurvey_Question.Content.ReadAsStringAsync();
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
            var resultUser = await HttpClient.PostAsJsonAsync("api/User", Adduser);
            //Assert
            resultUser.EnsureSuccessStatusCode();
            var userIdfromresult = await resultUser.Content.ReadAsStringAsync();
            var Addsurvey_Answer = new Survey_Answers
            {
                Survey_QuestionID = Convert.ToInt32(Survey_QuestionIdfromresult),
                UserID = Convert.ToInt32(userIdfromresult),
                Answer="Da"

            };
            var result = await HttpClient.PostAsJsonAsync("api/Survey_Answer", Addsurvey_Answer);
            //Assert
            result.EnsureSuccessStatusCode();
            var Survey_AnswerIdfromresult = await result.Content.ReadAsStringAsync();
            Survey_AnswerIdfromresult.Should().NotBeNullOrEmpty();
            var ResultofGetSurvey_AnswerByID = await HttpClient.GetAsync($"api/Survey_Answer/{Survey_AnswerIdfromresult}");
            ResultofGetSurvey_AnswerByID.EnsureSuccessStatusCode();
            var Survey_AnswerfromResults = await ResultofGetSurvey_AnswerByID.Content.ReadFromJsonAsync<Survey_Answers>();
            Survey_AnswerfromResults.Should().NotBeNull();
            Survey_AnswerfromResults.Id.ToString().Should().Be(Survey_AnswerIdfromresult);

        }

        [TestMethod]
        public async Task When_UpdateAnswer_ShouldChangeAnswerData()
        {
            var AddTopic = new Topics
            {
                Topic = "Food"
            };
            var resultTopic = await HttpClient.PostAsJsonAsync("api/Topic", AddTopic);


            resultTopic.EnsureSuccessStatusCode();
            var TopicIdFromResult = await resultTopic.Content.ReadAsStringAsync();

            var Addsurvey = new Survey
            {
                IDTopic = Convert.ToInt32(TopicIdFromResult),
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
            var Question_Type = new QuestionTypeModel
            {
                QuestionType = "Food"
            };
            var resultQuestionType = await HttpClient.PostAsJsonAsync("api/QuestionType", Question_Type);


            resultQuestionType.EnsureSuccessStatusCode();
            var QuestionTypeIdFromResult = await resultQuestionType.Content.ReadAsStringAsync();

            var Question = new QuestionModel
            {
                Question = "Ce?",
                Question_TypeID = Convert.ToInt32(QuestionTypeIdFromResult)
            };
            var results = await HttpClient.PostAsJsonAsync("api/Question", Question);


            results.EnsureSuccessStatusCode();
            var QuestionIdFromResult = await results.Content.ReadAsStringAsync();
            var Addsurvey_Question = new Survey_QuestionModel
            {
                QuestionsID = Convert.ToInt32(QuestionIdFromResult),
                SurveyID = Convert.ToInt32(surveyIdfromresult)

            };
            var resultSurvey_Question = await HttpClient.PostAsJsonAsync("api/Survey_Question", Addsurvey_Question);
            //Assert
            resultSurvey_Question.EnsureSuccessStatusCode();

            var Survey_QuestionIdfromresult = await resultSurvey_Question.Content.ReadAsStringAsync();
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
            var resultUser = await HttpClient.PostAsJsonAsync("api/User", Adduser);
            //Assert
            resultUser.EnsureSuccessStatusCode();
            var userIdfromresult = await resultUser.Content.ReadAsStringAsync();
            var Addsurvey_Answer = new Survey_AnswerModel
            {
                Survey_QuestionID = Convert.ToInt32(Survey_QuestionIdfromresult),
                UserID = Convert.ToInt32(userIdfromresult),
                Answer = "Da"

            };
            var result = await HttpClient.PostAsJsonAsync("api/Survey_Answer", Addsurvey_Answer);
            //Assert
            result.EnsureSuccessStatusCode();

            var Survey_AnswerIdfromresult = await result.Content.ReadAsStringAsync();
            var expectedDataChangeSurvey_Answer = "Nu";
            var survey_Answer = new Survey_Answers
            {
                Id=Convert.ToInt32(Survey_AnswerIdfromresult),
                Survey_QuestionID = Convert.ToInt32(Survey_QuestionIdfromresult),
                UserID = Convert.ToInt32(userIdfromresult),
                Answer = expectedDataChangeSurvey_Answer

            };
            var resultafter = await HttpClient.PutAsJsonAsync("api/Survey_Answer", survey_Answer);
            //Assert
            resultafter.EnsureSuccessStatusCode();
    
            var ResultofGetSurvey_AnswerByID = await HttpClient.GetAsync($"api/Survey_Answer/{Survey_AnswerIdfromresult}");
            ResultofGetSurvey_AnswerByID.EnsureSuccessStatusCode();
            var Survey_AnswerfromResults = await ResultofGetSurvey_AnswerByID.Content.ReadFromJsonAsync<Survey_Answers>();
            Survey_AnswerfromResults.Should().NotBeNull();
            Survey_AnswerfromResults.Id.ToString().Should().Be(Survey_AnswerIdfromresult);
            Survey_AnswerfromResults.Answer.Should().Be(expectedDataChangeSurvey_Answer);

        }

        [TestMethod]
        public async Task When_GetAll_ShouldGiveOKResponse()
        {



            var response = await HttpClient.GetAsync("/api/Survey_Answer");

            response.EnsureSuccessStatusCode();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

    }
}