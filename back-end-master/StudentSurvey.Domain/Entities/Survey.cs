using System;
using System.Collections.Generic;

namespace MyHotel.Domain.Entities
{
    public class Survey : BaseEntity
    {
        public int IDTopic  { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Opening_Time { get; set; }
        public DateTime Closing_Time { get; set; }
        public string Created_By { get; set; }
        public string Modified_By { get; set; }            
        public User User { get; set; }
        public Topics Topics { get; set; }
        public Consent Consent{ get; set; } 
        public ICollection<Survey_Questions> SurveyQuestions { get; set; }
    }
}
