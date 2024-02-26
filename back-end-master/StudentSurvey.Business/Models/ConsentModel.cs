using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Business.Models
{
    public class ConsentModel
    {
        public int UserID { get; set; }
        public int SurveyID { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool Agree { get; set; }
    }
}
