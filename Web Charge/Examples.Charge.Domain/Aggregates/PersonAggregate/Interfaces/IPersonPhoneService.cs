
using System.Collections.Generic;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneService
    {
        bool InsertPersonPhone(PersonPhone request);
        bool UpdatePersonPhone(PersonPhone request, string newPhoneNumber);
        bool DeletePersonPhone(PersonPhone request);
        List<PersonPhoneResponseDto> SelectPersonPhone(PersonPhoneResponseDto request);
        List<PersonPhoneResponseDto> SelectAllPersonPhone();
    }
}
