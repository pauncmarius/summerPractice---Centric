using MyHotel.Domain.Entities;
using StudentSurvey.Domain.IRepositories;
using StudentSurvey.Persistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Persistance.Repositories
{
    public class SurveyRepository : BaseRepository<Survey>, ISurveyRepository
    {
        public SurveyRepository(StudentSurveyDbContext studentSurveyDbContext) :
          base(studentSurveyDbContext)
        {

        }

        public int GetByName(String name)
        {
            var survey = (from x in _dbContext.Surveys
                          where x.Name == name
                          select x.Id).FirstOrDefault();
            return survey;
        }
  
    }
}
