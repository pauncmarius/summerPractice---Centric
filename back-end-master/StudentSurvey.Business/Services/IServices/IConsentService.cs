using MyHotel.Domain.Entities;
using StudentSurvey.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Business.Services.IServices
{
    public interface IConsentService
    {
        public IEnumerable<Consent> GetConsents();
        public Consent GetConsent(int id);
        public int AddConsent(ConsentModel consent);
        public void UpdateConsent(Consent consent);
        public void DeleteConsent(int id);

    }
}
