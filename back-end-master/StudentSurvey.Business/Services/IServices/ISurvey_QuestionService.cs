using MyHotel.Domain.Entities;
using StudentSurvey.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Business.Services.IServices
{
    public interface ISurvey_QuestionService
    {
        public IEnumerable<Survey_Questions> GetSurvey_Questions();
        public Survey_Questions GetSurvey_Question(int id);
        public int AddSurvey_Question(Survey_QuestionModel survey);
        public void UpdateSurvey_Question(Survey_Questions survey);
        public void DeleteSurvey_Question(int id);
    }
}
