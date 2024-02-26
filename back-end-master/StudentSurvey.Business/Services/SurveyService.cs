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
    public class SurveyService: ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository;
     
        private readonly IMapper _mapper;

        public SurveyService(ISurveyRepository surveyRepository, IMapper mapper)
        {
            _surveyRepository = surveyRepository;
            _mapper = mapper;
        }

        public IEnumerable<Survey> GetSurveys()
        {
            return _surveyRepository.ListAll();
        }

        public Survey GetSurvey(int id)
        {
            return _surveyRepository.GetById(id);
        }

        public int AddSurvey(SurveyModel survey)
        {
            var newSurvey = _surveyRepository.Add(_mapper.Map<Survey>(survey));
            return newSurvey.Id;
        }
        public int GetByName(string name)
        {
            return _surveyRepository.GetByName(name);
        }

        public void UpdateSurvey(Survey survey)
        {
            _surveyRepository.Update(survey);
        }

        public void DeleteSurvey(int id)
        {
            var survey = _surveyRepository.GetById(id);
            if(survey!=null)
            {
                _surveyRepository.Delete(survey);
            }
        }

        public void DeleteByName(string name)
        {
            var surveyId = _surveyRepository.GetByName(name);
            var survey = _surveyRepository.GetById(surveyId);

            if(survey!=null)
            {
                _surveyRepository.Delete(survey);
            }
        }
       
    }
}
