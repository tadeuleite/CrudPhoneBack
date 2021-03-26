using AutoMapper;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Charge.Application.Facade
{
    public class PersonPhoneFacade : IPersonPhoneFacade
    {
        private readonly IPersonPhoneService _personPhoneService;
        private readonly IMapper _mapper;

        public PersonPhoneFacade(IPersonPhoneService personPhoneService, IMapper mapper)
        {
            _personPhoneService = personPhoneService;
            _mapper = mapper;
        }

        public PersonPhoneResponse InsertPersonPhone(PersonPhone request)
        {
            var response = new PersonPhoneResponse();
            try
            {
                var result = _personPhoneService.InsertPersonPhone(request);
                response.Success = result;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(ex);
            }

            return response;
        }

        public PersonPhoneResponse UpdatePersonPhone(int personId, int typePhoneId, string oldPhone, string newPhoneNumber)
        {
            var request = new PersonPhone()
            {
                BusinessEntityID = personId,
                PhoneNumber = oldPhone,
                PhoneNumberTypeID = typePhoneId
            };

            var response = new PersonPhoneResponse();
            try
            {
                var result = _personPhoneService.UpdatePersonPhone(request, newPhoneNumber);
                response.Success = result;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(ex);
            }

            return response;
        }

        public PersonPhoneResponse DeletePersonPhone(int personId, int typePhoneId, string phoneNumber)
        {
            var request = new PersonPhone()
            {
                BusinessEntityID = personId,
                PhoneNumber = phoneNumber,
                PhoneNumberTypeID = typePhoneId
            };

            var response = new PersonPhoneResponse();
            try
            {
                var result = _personPhoneService.DeletePersonPhone(request);
                response.Success = result;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(ex);
            }

            return response;
        }

        public PersonPhoneResponse SelectPersonPhone(PersonPhone request)
        {
            var response = new PersonPhoneResponse();
            try
            {
                var result = _personPhoneService.SelectPersonPhone(request);
                response.Success = true;
                response.PersonObjects = result;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(ex);
            }

            return response;
        }
    }
}
