using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Domain.Entities
{
    public class Answers: BaseEntity
    {
        public int QuestionID { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }

        public Questions Question { get; set; }
    }
}
