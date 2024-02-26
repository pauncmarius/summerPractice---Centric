using MyHotel.Domain.Entities;
using StudentSurvey.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Business.Services.IServices
{
    public interface IUserService
    {
        public IEnumerable<User> GetUsers();
        public User GetUser(int id);
        public int GetByEmail(string email);
        public int AddUser(UserModel user);
        public void UpdateUser(User user);
        public void DeleteUser(int id);

        


    }
}
