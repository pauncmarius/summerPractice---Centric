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
    public class Survey_QuestionService: ISurvey_QuestionService
    {
        private readonly ISurvey_QuestionsRepository _survey_QuestionsRepository;
        private readonly IMapper _mapper;
        public Survey_QuestionService(ISurvey_QuestionsRepository survey_QuestionsRepository, IMapper mapper)
        {
            _survey_QuestionsRepository = survey_QuestionsRepository;
            _mapper = mapper;
        }
        public IEnumerable<Survey_Questions> GetSurvey_Questions()
        {
            return _survey_QuestionsRepository.ListAll();

        }
        public Survey_Questions GetSurvey_Question(int id)
        {
            return _survey_QuestionsRepository.GetById(id);

        }
        public int AddSurvey_Question(Survey_QuestionModel surveyQ)
        {
            var newSurveyQ = _survey_QuestionsRepository.Add(_mapper.Map<Survey_Questions>(surveyQ));
            return newSurveyQ.Id;
        }
        public void UpdateSurvey_Question(Survey_Questions surveyQ)
        {
            _survey_QuestionsRepository.Update(surveyQ);
        }
        public void DeleteSurvey_Question(int id)
        {
            var surveyQ = _survey_QuestionsRepository.GetById(id);
            if(surveyQ!=null)
            {
                _survey_QuestionsRepository.Delete(surveyQ);
            }
        }

    }
}
