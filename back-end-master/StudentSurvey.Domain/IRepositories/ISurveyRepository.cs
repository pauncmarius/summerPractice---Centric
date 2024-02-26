using MyHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Domain.IRepositories
{
    public interface ISurveyRepository: IBaseRepository <Survey>
    {
        public int GetByName(string name);
        
    }
}
