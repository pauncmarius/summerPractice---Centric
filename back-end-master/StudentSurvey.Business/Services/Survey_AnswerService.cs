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
    public class Survey_AnswerService: ISurvey_AnswerService
    {
        private readonly ISurvey_AnswersRepository _survey_AnswerRepository;
        private readonly IMapper _mapper;

        public Survey_AnswerService(ISurvey_AnswersRepository survey_AnswerRepository, IMapper mapper)
        {
            _survey_AnswerRepository = survey_AnswerRepository;
            _mapper = mapper;
        }

        public IEnumerable<Survey_Answers> GetSurvey_Answers()
        {
            return _survey_AnswerRepository.ListAll();
        }

        public Survey_Answers GetSurvey_Answer(int id)
        {
            return _survey_AnswerRepository.GetById(id);
        }

        public int AddSurvey_Answer(Survey_AnswerModel answer)
        {
            var newSurvAnswer = _survey_AnswerRepository.Add(_mapper.Map<Survey_Answers>(answer));
            return newSurvAnswer.Id;
        }
        public void UpdateSurvey_Answer(Survey_Answers answer)
        {
            _survey_AnswerRepository.Update(answer);
        }

        public void DeleteSurvey_Answer(int id)
        {
            var answer = _survey_AnswerRepository.GetById(id);
                if(answer!=null)
            {
                _survey_AnswerRepository.Delete(answer);
            }
        }
    }
}
