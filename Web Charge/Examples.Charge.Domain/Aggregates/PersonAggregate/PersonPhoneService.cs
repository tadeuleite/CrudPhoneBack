using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;
        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository)
        {
            _personPhoneRepository = personPhoneRepository;
        }

        public bool InsertPersonPhone(PersonPhone request) => _personPhoneRepository.InsertPersonPhone(request);

        public bool UpdatePersonPhone(PersonPhone request, string newPhoneNumber) => _personPhoneRepository.UpdatePersonPhone(request, newPhoneNumber);

        public bool DeletePersonPhone(PersonPhone request) => _personPhoneRepository.DeletePersonPhone(request);

        public List<PersonPhoneResponseDto> SelectPersonPhone(PersonPhoneResponseDto request) => _personPhoneRepository.SelectPersonPhone(request);

        public List<PersonPhoneResponseDto> SelectAllPersonPhone() => _personPhoneRepository.SelectAllPersonPhone();
    }
}
