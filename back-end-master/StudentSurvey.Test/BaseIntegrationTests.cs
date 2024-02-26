using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentSurvey.Api;
using StudentSurvey.Api.Controllers;
using StudentSurvey.Persistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Test
{
    public class BaseIntegrationTests
    {
        private WebApplicationFactory<Startup> _application;

        protected HttpClient HttpClient { get; private set; }

        [TestInitialize]
        public async Task TestInitialize()
        {
            _application = new WebApplicationFactory<Startup>()
               .WithWebHostBuilder(builder =>
               {

               });

            HttpClient = _application.CreateClient();

            await CleanupDatabase();
        }

       [TestCleanup]
        public async Task TestCleanup()
        {
            await CleanupDatabase();
        }

        private async Task CleanupDatabase()
        {
            using var scope = _application.Services.CreateScope();
            var databaseContext = scope.ServiceProvider.GetRequiredService<StudentSurveyDbContext>();
            databaseContext.Database.Migrate();
            databaseContext.Answers.RemoveRange(databaseContext.Answers.ToList());
            databaseContext.Questions.RemoveRange(databaseContext.Questions.ToList());
            databaseContext.Question_Types.RemoveRange(databaseContext.Question_Types.ToList());
            databaseContext.Consents.RemoveRange(databaseContext.Consents.ToList());
            await databaseContext.SaveChangesAsync();
        }
    }
}
