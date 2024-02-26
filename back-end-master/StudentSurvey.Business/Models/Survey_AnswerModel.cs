using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Business.Models
{
    public class Survey_AnswerModel
    {
        public int Survey_QuestionID { get; set; }
        public int UserID { get; set; }
        public string Answer { get; set; }
    }
}
