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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(StudentSurveyDbContext studentSurveyDbContext) :
          base(studentSurveyDbContext)
        {

        }
        public int GetUserByEmail(string email)
        {
            var user = (from x in _dbContext.Users
                        where x.Email == email
                        select x.Id).FirstOrDefault();
            return user;
        }
    }
}
