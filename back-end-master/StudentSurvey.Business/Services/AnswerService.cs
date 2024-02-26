using AutoMapper;
using MyHotel.Domain.Entities;
using StudentSurvey.Business.Models;
using StudentSurvey.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Business.Services.IServices
{
    public class AnswerService :  IAnswerService
    {
        private readonly IAnswersRepository _answersRepository;
        private readonly IMapper _mapper;


        public AnswerService(IAnswersRepository answersRepository, IMapper mapper)
        {
            _answersRepository = answersRepository;
            _mapper = mapper;
        }

        public int AddAnswer(AnswerModel answer)
        {
            var newAnswer = _answersRepository.Add(_mapper.Map<Answers>(answer));
            return newAnswer.Id;
        }

        public IEnumerable<Answers> GetAnswers()
        {
            return _answersRepository.ListAll();
        }
        public Answers GetAnswer(int id)
        {
            return _answersRepository.GetById(id);
        }
        public void UpdateAnswer(Answers question)
        {
            _answersRepository.Update(question);
        }
        public void DeleteAnswer(int id)
        {
            var answer = _answersRepository.GetById(id);
            if (answer != null)
            {
                _answersRepository.Delete(answer);
            }
        }
    }
}
