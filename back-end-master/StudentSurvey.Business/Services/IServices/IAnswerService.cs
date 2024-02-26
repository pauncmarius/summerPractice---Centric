using MyHotel.Domain.Entities;
using StudentSurvey.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Business.Services.IServices
{
    public interface IAnswerService
    {
        int AddAnswer(AnswerModel answer);

        public IEnumerable<Answers> GetAnswers();
        public Answers GetAnswer(int id);
        public void UpdateAnswer(Answers user);
        public void DeleteAnswer(int id);

    }
}
