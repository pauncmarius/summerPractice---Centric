using AutoMapper;
using MyHotel.Domain.Entities;
using StudentSurvey.Business.Models;
using StudentSurvey.Business.Services.IServices;
using StudentSurvey.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Business.Services
{
    public class ConsentService: IConsentService
    {
        private readonly IConsentRepository _consentRepository;
        private readonly IMapper _mapper;

        public ConsentService(IConsentRepository consentRepository, IMapper mapper)
        {
            _consentRepository = consentRepository;
            _mapper = mapper;
        }

        public IEnumerable<Consent> GetConsents()
        {
            return _consentRepository.ListAll();
        }

        public Consent GetConsent(int id)
        {
            return _consentRepository.GetById(id);
        }

        public int AddConsent(ConsentModel consent)
        {
            var newConsent = _consentRepository.Add(_mapper.Map<Consent>(consent));
            return newConsent.Id;
        }

        public void UpdateConsent(Consent consent)
        {
            _consentRepository.Update(consent);
        }

        public void DeleteConsent(int id)
        {
            var consent = _consentRepository.GetById(id);
                if(consent!=null)
            {
                _consentRepository.Delete(consent);
            }
        }
    }
}
