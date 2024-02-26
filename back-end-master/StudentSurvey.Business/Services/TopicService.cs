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
    public class TopicService : ITopicService
    {
        private readonly ITopicsRepository _topicRepository;
        private readonly IMapper _mapper;

        public TopicService(ITopicsRepository topicsRepository, IMapper mapper)
        {
            _topicRepository = topicsRepository;
            _mapper = mapper;
        }
        public IEnumerable<Topics> GetTopics()
        {
            return _topicRepository.ListAll();
        }
        public Topics GetTopic(int id)
        {
            return _topicRepository.GetById(id);
        }

        public int AddTopic(TopicModel topic)
        {
            var newTopic = _topicRepository.Add(_mapper.Map<Topics>(topic));
            return newTopic.Id;
        }
        public void UpdateTopic(Topics topic)
        {
            _topicRepository.Update(topic);
        }
        public void DeleteTopic(int id)
        {
            var survey = _topicRepository.GetById(id);
            if (survey != null)
            {
                _topicRepository.Delete(survey);
            }
        }

       
    }
}
