using AutoMapper;
using MyHotel.Domain.Entities;
using StudentSurvey.Business.Models;
using StudentSurvey.Business.Services.IServices;
using StudentSurvey.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Business.Services
{
    public class QuestionService: IQuestionService
    {
        private readonly IQuestionsRepository _questionsRepository;
        private readonly IQuestion_TypeRepository _question_TypeRepository;
        private readonly IMapper _mapper;

        public QuestionService(
            IQuestionsRepository questionsRepository,
            IQuestion_TypeRepository question_TypeRepository,
            IMapper mapper)
        {
            _questionsRepository = questionsRepository;
            _question_TypeRepository = question_TypeRepository;
            _mapper = mapper;
        }

        public int AddQuestion(QuestionModel question)
        {
            var newQuestion = _questionsRepository.Add(_mapper.Map<Questions>(question));
            return newQuestion.Id;
        }
        public int AddQuestionType(QuestionTypeModel questionType)
        {
            var newQuestionType = _question_TypeRepository.Add(_mapper.Map<Question_Type>(questionType));
            return newQuestionType.Id;
        }

        public IEnumerable<Questions> GetQuestions()
        {
            return _questionsRepository.ListAll();
        }
        public Questions GetQuestion(int id)
        {
            return _questionsRepository.GetById(id);
        }
        public void UpdateQuestion(Questions question)
        {
            _questionsRepository.Update(question);
        }
        public void DeleteQuestion(int id)
        {
            var question = _questionsRepository.GetById(id);
            if(question!=null)
            {
                _questionsRepository.Delete(question);
            }
        }


        public Question_Type GetQuestion_TypeID(int id)
        {
            return _question_TypeRepository.GetById(id);
        }
        public IEnumerable<Question_Type> GetQuestion_Type()
        {
            return _question_TypeRepository.ListAll();
        }

    }
}
