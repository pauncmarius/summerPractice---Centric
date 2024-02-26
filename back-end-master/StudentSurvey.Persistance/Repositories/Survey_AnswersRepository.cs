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
    class Survey_AnswersRepository: BaseRepository<Survey_Answers>, ISurvey_AnswersRepository
    {
        public Survey_AnswersRepository(StudentSurveyDbContext studentSurveyDbContext) :
          base(studentSurveyDbContext)
        {

        }
    }
}
