using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Domain.Entities
{
    public class Topics : BaseEntity
    {
        public string Topic { get; set; }
        public ICollection<Survey> Surveys { get; set; }
    }
}
