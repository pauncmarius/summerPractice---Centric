using MyHotel.Domain.Entities;
using StudentSurvey.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Business.Services.IServices
{
    public interface ITopicService
    {
        public IEnumerable<Topics> GetTopics();
        public Topics GetTopic(int id);
        public int AddTopic(TopicModel topic);
        public void UpdateTopic(Topics topic);
        public void DeleteTopic(int id);
    }
}
