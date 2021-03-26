using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonPhoneFacade
    {
        PersonPhoneResponse InsertPersonPhone(PersonPhoneResponseDto request);
        PersonPhoneResponse UpdatePersonPhone(PersonPhoneResponseDto request, string newPhoneNumber);
        PersonPhoneResponse DeletePersonPhone(int personId, int typePhoneId, string phoneNumber);
        PersonPhoneResponse SelectPersonPhone(string phoneNumber);
        PersonPhoneResponse SelectAllPersonPhone();
    }
}
