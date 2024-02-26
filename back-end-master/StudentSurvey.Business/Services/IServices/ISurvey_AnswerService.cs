using MyHotel.Domain.Entities;
using StudentSurvey.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Business.Services.IServices
{
    public interface ISurvey_AnswerService
    {
        public IEnumerable<Survey_Answers> GetSurvey_Answers();
        public Survey_Answers GetSurvey_Answer(int id);
        public int AddSurvey_Answer(Survey_AnswerModel answer);
        public void UpdateSurvey_Answer(Survey_Answers answer);
        public void DeleteSurvey_Answer(int id);

    }
}
