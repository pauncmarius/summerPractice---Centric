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
    public class Survey_QuestionControllerTest : BaseIntegrationTests
    {

        [TestMethod]
        public async Task When_AddSurvey_Question_ShouldAddSurvey_Question()
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
                SurveyID=Convert.ToInt32(surveyIdfromresult)

            };
            var result = await HttpClient.PostAsJsonAsync("api/Survey_Question", Addsurvey_Question);
            //Assert
            result.EnsureSuccessStatusCode();
            var Survey_QuestionIdfromresult = await result.Content.ReadAsStringAsync();
            Survey_QuestionIdfromresult.Should().NotBeNullOrEmpty();
            var ResultofGetSurvey_QuestionByID = await HttpClient.GetAsync($"api/Survey_Question/{Survey_QuestionIdfromresult}");
            ResultofGetSurvey_QuestionByID.EnsureSuccessStatusCode();
            var Survey_QuestionfromResults = await ResultofGetSurvey_QuestionByID.Content.ReadFromJsonAsync<Survey_Questions>();
            Survey_QuestionfromResults.Should().NotBeNull();
            Survey_QuestionfromResults.Id.ToString().Should().Be(Survey_QuestionIdfromresult);

        }

        /*[TestMethod]
        public async Task When_UpdateAnswer_ShouldChangeAnswerData()
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
            var result = await HttpClient.PostAsJsonAsync("api/Survey_Question", Addsurvey_Question);
            //Assert
            
            var expectedDataChangeSurvey_Question = 1;
            result.EnsureSuccessStatusCode();
            var AnswerIdfromresult = await result.Content.ReadAsStringAsync();
            var survey_Question = new Survey_QuestionModel
            {
                Id=Convert.ToInt32(AnswerIdfromresult),
                QuestionsID = expectedDataChangeSurvey_Question,
                SurveyID = Convert.ToInt32(surveyIdfromresult)

            };
            var resultforUpdateAnswer = await HttpClient.PutAsJsonAsync("api/Survey_Question", survey_Question);
            //Assert

            resultforUpdateAnswer.EnsureSuccessStatusCode();

            var ResultofGetAnswerByID = await HttpClient.GetAsync($"api/Survey_Question/{AnswerIdfromresult}");
            ResultofGetAnswerByID.EnsureSuccessStatusCode();
            var AnswerfromResults = await ResultofGetAnswerByID.Content.ReadFromJsonAsync<Survey_Questions>();
            AnswerfromResults.Should().NotBeNull();
            AnswerfromResults.Id.ToString().Should().Be(AnswerIdfromresult);
            AnswerfromResults.QuestionsID.Should().Be(expectedDataChangeSurvey_Question);


        }*/

        [TestMethod]
        public async Task When_GetAll_ShouldGiveOKResponse()
        {



            var response = await HttpClient.GetAsync("/api/Survey_Question");

            response.EnsureSuccessStatusCode();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

    }
}