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
    class Question_TypeRepository: BaseRepository<Question_Type>, IQuestion_TypeRepository
    {
        public Question_TypeRepository(StudentSurveyDbContext studentSurveyDbContext) :
          base(studentSurveyDbContext)
        {

        }
    }
}
