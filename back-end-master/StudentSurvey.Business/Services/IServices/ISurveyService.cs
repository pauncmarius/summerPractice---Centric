using MyHotel.Domain.Entities;
using StudentSurvey.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Business.Services.IServices
{
    public interface ISurveyService
    {
        public IEnumerable<Survey> GetSurveys();
        public Survey GetSurvey(int id);
        public int AddSurvey(SurveyModel survey);
        public void UpdateSurvey(Survey survey);
        public void DeleteSurvey(int id);

        public void DeleteByName(string name);
       
    }
}
