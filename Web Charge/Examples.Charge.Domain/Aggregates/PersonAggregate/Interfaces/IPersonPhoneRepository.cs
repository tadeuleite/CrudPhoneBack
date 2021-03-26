using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneRepository
    {
        bool InsertPersonPhone(PersonPhone request, IDbContextTransaction transaction = null);
        bool UpdatePersonPhone(PersonPhone request, string newPhoneNumber, IDbContextTransaction transaction = null);
        bool DeletePersonPhone(PersonPhone request, IDbContextTransaction transaction = null);
        List<PersonPhoneResponseDto> SelectPersonPhone(PersonPhoneResponseDto request);
        List<PersonPhoneResponseDto> SelectAllPersonPhone();
    }
}
