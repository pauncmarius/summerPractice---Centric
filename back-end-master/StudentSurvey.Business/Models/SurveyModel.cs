using MyHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Business.Models
{
    public class SurveyModel
    {
        public int IDTopic { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Opening_Time { get; set; }
        public DateTime Closing_Time { get; set; }
        public string Created_By { get; set; }
        public string Modified_By { get; set; }
        

    }
}
