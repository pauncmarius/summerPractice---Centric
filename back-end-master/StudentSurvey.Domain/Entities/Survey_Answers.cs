using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Domain.Entities
{
    public class Survey_Answers : BaseEntity
    {
        public int Survey_QuestionID { get; set; }
        public int UserID { get; set; }
        public string Answer { get; set; }
        public User User { get; set; }
        public Survey_Questions Survey_Questions { get; set; }
    }
}
