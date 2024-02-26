using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Domain.Entities
{
    public class Consent: BaseEntity
    {
        public int UserID { get; set; }
        public int SurveyID { get; set; }
        public DateTime ExpirationDate{ get; set; }
        public bool Agree { get; set; }

        public User User { get; set; }
        public Survey Survey { get; set; }
    }
}
