using Examples.Charge.Domain.Aggregates.ExampleAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool InsertPersonPhone(PersonPhone request, IDbContextTransaction transaction = null)
        {
            var commitRollback = transaction == null;

            using (transaction = transaction == null ? _context.Database.BeginTransaction() : transaction)
            {
                var success = 0;
                _context.PersonPhone.Add(request);

                if (commitRollback)
                {
                    success = _context.SaveChanges();
                    transaction.Commit();
                }

                return success > 0 || !commitRollback;
            }
        }

        public bool UpdatePersonPhone(PersonPhone request, string newPhoneNumber, IDbContextTransaction transaction = null)
        {
            using (transaction = transaction == null ? _context.Database.BeginTransaction() : transaction)
            {
                var successSaveChanges = false;

                var successDelete = DeletePersonPhone(request, transaction);
                request.PhoneNumber = newPhoneNumber;
                var successInsert = InsertPersonPhone(request, transaction);

                if (successDelete && successInsert)
                {
                    successSaveChanges = _context.SaveChanges() > 0;
                }
                else
                {
                    transaction.Rollback();
                }

                return successSaveChanges;
            }
        }

        public bool DeletePersonPhone(PersonPhone request, IDbContextTransaction transaction = null)
        {
            var commitRollback = transaction == null;

            using (transaction = transaction == null ? _context.Database.BeginTransaction() : transaction)
            {
                var success = 0;

                var entity = _context.PersonPhone.Find(request.BusinessEntityID, request.PhoneNumber, request.PhoneNumberTypeID);
                _context.Entry(entity).State = EntityState.Deleted;

                if (commitRollback)
                {
                    success = _context.SaveChanges();
                    transaction.Commit();
                }

                return success > 0 || !commitRollback;
            }
        }

        public List<PersonPhoneResponseDto> SelectPersonPhone(PersonPhone request)
        {
            var data = (from phone in _context.PersonPhone
                        join person in _context.Person
                        on phone.BusinessEntityID equals person.BusinessEntityID
                        join phoneType in _context.PhoneNumberType
                        on phone.PhoneNumberTypeID equals phoneType.PhoneNumberTypeID
                        where phone.BusinessEntityID == request.BusinessEntityID
                        select new PersonPhoneResponseDto { PersonName = person.Name, PhoneNumber = phone.PhoneNumber, PhoneType = phoneType.Name }).ToList();

            return data;
        }
    }
}
