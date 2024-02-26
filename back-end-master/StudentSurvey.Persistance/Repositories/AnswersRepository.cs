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
    public class AnswersRepository : BaseRepository<Answers>, IAnswersRepository
    {
        public AnswersRepository(StudentSurveyDbContext studentSurveyDbContext) :
          base(studentSurveyDbContext)
        {

        }
    }
}
