using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentSurvey.Domain.IRepositories;
using StudentSurvey.Persistance.Data;
using StudentSurvey.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StudentSurveyDbContext>(options =>
                                options.UseSqlServer(configuration.GetConnectionString("StudentSurveyConnectionString")));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IAnswersRepository, AnswersRepository>();
            services.AddScoped<IConsentRepository, ConsentRepository>();
            services.AddScoped<IQuestion_TypeRepository, Question_TypeRepository>();
            services.AddScoped<IQuestionsRepository, QuestionsRepository>();     
            services.AddScoped<ISurvey_AnswersRepository, Survey_AnswersRepository>();
            services.AddScoped<ISurvey_QuestionsRepository, Survey_QuestionsRepository>();
            services.AddScoped<ISurveyRepository, SurveyRepository>();
            services.AddScoped<ITopicsRepository, TopicsRepository>();
            services.AddScoped<IUserRepository, UserRepository>();


            return services;
        }
    }
}
