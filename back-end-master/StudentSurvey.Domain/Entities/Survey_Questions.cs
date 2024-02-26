using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Domain.Entities
{
    public class Survey_Questions : BaseEntity
    {
        public int SurveyID{ get; set; }
        public int QuestionsID { get; set; }
        public Survey Survey { get; set; }
        public Questions Question { get; set; }
        //public Survey_Answers Survey_Answers { get; set; }
    }
}
