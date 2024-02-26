using System.Collections.Generic;

namespace MyHotel.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Hashed_Password { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<Survey> Surveys { get; set; }
        public ICollection<Consent> Consents { get; set; }
        public ICollection<Survey_Answers> SurveyAnswers { get; set; }

    }
}
