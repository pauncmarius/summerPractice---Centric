using MyHotel.Domain.Entities;
using StudentSurvey.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Business.Services.IServices
{
    public interface IQuestionService
    {
        public int AddQuestion(QuestionModel question);
        public IEnumerable<Questions> GetQuestions();
        public Questions GetQuestion(int id);
        public void UpdateQuestion(Questions user);
        public void DeleteQuestion(int id);

        public int AddQuestionType(QuestionTypeModel questionType);
        public Question_Type GetQuestion_TypeID(int id);
        public IEnumerable<Question_Type> GetQuestion_Type();

    }
}
