using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonPhoneFacade
    {
        PersonPhoneResponse InsertPersonPhone(PersonPhone request);
        PersonPhoneResponse UpdatePersonPhone(int personId, int typePhoneId, string oldPhone, string newPhoneNumber);
        PersonPhoneResponse DeletePersonPhone(int personId, int typePhoneId, string phoneNumber);
        PersonPhoneResponse SelectPersonPhone(PersonPhone request);
    }
}
