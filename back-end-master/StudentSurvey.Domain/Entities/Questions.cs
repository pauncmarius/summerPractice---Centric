using System.Collections.Generic;

namespace MyHotel.Domain.Entities
{
    public class Questions : BaseEntity
    {
        public int Question_TypeID { get; set; }
        public string Question { get; set; }

        public Answers Answers { get; set; }

        public ICollection<Survey_Questions> SurveyQuestions { get; set; }
    }
}
