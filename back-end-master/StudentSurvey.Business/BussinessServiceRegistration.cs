using Microsoft.Extensions.DependencyInjection;
using StudentSurvey.Business.Services;
using StudentSurvey.Business.Services.IServices;
using System.Reflection;

namespace StudentSurvey.Business
{
    public static class BussinessServiceRegistration 
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
           
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISurveyService, SurveyService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<ISurvey_QuestionService, Survey_QuestionService>();
            services.AddScoped<ISurvey_AnswerService, Survey_AnswerService>();
            services.AddScoped<IConsentService, ConsentService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
