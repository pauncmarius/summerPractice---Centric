﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Business.Models
{
    public class UserModel
    {
      
        
        public string Username { get; set; }
     
        public string FirstName { get; set; }
    
        public string LastName { get; set; }
      
        public string Email { get; set; }
     
        public string PhoneNumber { get; set; }
  
        public string Hashed_Password { get; set; }
     
        public bool IsAdmin { get; set; }

    }
}
