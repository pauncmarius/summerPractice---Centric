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
    public class AnswerControllerTest : BaseIntegrationTests
    {

        [TestMethod]
        public async Task When_AddAnswer_ShouldAddAnswer()
        {
            var Question_Type = new QuestionTypeModel
            {
                QuestionType="Food"
            };
            var resultss = await HttpClient.PostAsJsonAsync("api/QuestionType", Question_Type);


            resultss.EnsureSuccessStatusCode();
            var QuestionTypeIdFromResult = await resultss.Content.ReadAsStringAsync();
            
            var Question = new QuestionModel
            {
                Question = "Ce?",
                Question_TypeID = Convert.ToInt32(QuestionTypeIdFromResult)
            };
            var results = await HttpClient.PostAsJsonAsync("api/Question", Question);
            
           
            results.EnsureSuccessStatusCode();
            var QuestionIdFromResult = await results.Content.ReadAsStringAsync();
            var Addanswer = new AnswerModel
            {
                QuestionID =Convert.ToInt32(QuestionIdFromResult),
                Option1 = "Avem",
                Option2 = "Bbe",
                Option3 = "Cer", 
                Option4 = "Dor",
                
            };
            var result = await HttpClient.PostAsJsonAsync("api/Answer", Addanswer);
            //Assert
            result.EnsureSuccessStatusCode();
            var AnswerIdfromresult = await result.Content.ReadAsStringAsync();
            AnswerIdfromresult.Should().NotBeNullOrEmpty();
            var ResultofGetAnswerByID = await HttpClient.GetAsync($"api/Answer/{AnswerIdfromresult}");
            ResultofGetAnswerByID.EnsureSuccessStatusCode();
            var AnswerfromResults = await ResultofGetAnswerByID.Content.ReadFromJsonAsync<Answers>();
            AnswerfromResults.Should().NotBeNull();
            AnswerfromResults.Id.ToString().Should().Be(AnswerIdfromresult);

        }

        [TestMethod]
        public async Task When_UpdateAnswer_ShouldChangeAnswerData()
        {
            var Question_Type = new QuestionTypeModel
            {
                QuestionType = "Food"
            };
            var resultss = await HttpClient.PostAsJsonAsync("api/QuestionType", Question_Type);


            resultss.EnsureSuccessStatusCode();
            var QuestionTypeIdFromResult = await resultss.Content.ReadAsStringAsync();
            var Question = new QuestionModel
            {
                Question = "Ce?",
                Question_TypeID = Convert.ToInt32(QuestionTypeIdFromResult)
            };
            var results = await HttpClient.PostAsJsonAsync("api/Question", Question);


            results.EnsureSuccessStatusCode();
            var QuestionIdFromResult = await results.Content.ReadAsStringAsync();

            var Addanswer = new AnswerModel
            {
                QuestionID = Convert.ToInt32(QuestionIdFromResult),
                Option1 = "Are",
                Option2 = "Bere",
                Option3 = "Cere",
                Option4 = "Doare"
            };
            var result = await HttpClient.PostAsJsonAsync("api/Answer", Addanswer);
            //Assert
            result.EnsureSuccessStatusCode();
            var AnswerIdfromresult = await result.Content.ReadAsStringAsync();

            var expectedDataChangeAnswer = "Merge";
            var answer = new Answers
            {
                Id = Convert.ToInt32(AnswerIdfromresult),
                QuestionID = Convert.ToInt32(QuestionIdFromResult),
                Option1 = "Are",
                Option2 = "Bere",
                Option3 = "Cere",
                Option4 = expectedDataChangeAnswer
            };
            var resultforUpdateAnswer = await HttpClient.PutAsJsonAsync("api/Answer", answer);
            //Assert

            resultforUpdateAnswer.EnsureSuccessStatusCode();

            var ResultofGetAnswerByID = await HttpClient.GetAsync($"api/Answer/{AnswerIdfromresult}");
            ResultofGetAnswerByID.EnsureSuccessStatusCode();
            var AnswerfromResults = await ResultofGetAnswerByID.Content.ReadFromJsonAsync<Answers>();
            AnswerfromResults.Should().NotBeNull();
            AnswerfromResults.Id.ToString().Should().Be(AnswerIdfromresult);
            AnswerfromResults.Option4.Should().Be(expectedDataChangeAnswer);


        }

        [TestMethod]
        public async Task When_GetAll_ShouldGiveOKResponse()
        {



            var response = await HttpClient.GetAsync("/api/Answer");

            response.EnsureSuccessStatusCode();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

    }
}