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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.ListAll();
        }

        public User GetUser(int id)
        {
            return _userRepository.GetById(id);
        }

        public int GetByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }
        public int AddUser(UserModel user)
        {
            var newUser = _userRepository.Add(_mapper.Map<User > (user));
            return newUser.Id;
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(int id)
        {
            var user = _userRepository.GetById(id);
            if (user != null)
            {
                _userRepository.Delete(user);
            }
        }

  

    }
}
