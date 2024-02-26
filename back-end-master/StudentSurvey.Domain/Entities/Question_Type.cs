using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Domain.Entities
{
    public class Question_Type : BaseEntity
    {
        public string QuestionType { get; set; }

        public ICollection<Questions> Questions { get; set; }
    }
}
