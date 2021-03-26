using Microsoft.AspNetCore.Mvc;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonPhoneController : BaseController
    {
        private IPersonPhoneFacade _facadePhone;

        public PersonPhoneController(IPersonPhoneFacade facadePhone)
        {
            _facadePhone = facadePhone;
        }

        [HttpPost]
        public IActionResult InsertPersonPhone(PersonPhone request)
        {
            var response = _facadePhone.InsertPersonPhone(request);

            return Response(response);
        }

        [HttpPut]
        public IActionResult UpdatePersonPhone([FromHeader] int personId, [FromHeader] int TypePhoneId, [FromHeader] string oldPhone, [FromHeader] string newPhoneNumber)
        {
            var response = _facadePhone.UpdatePersonPhone(personId, TypePhoneId, oldPhone, newPhoneNumber);

            return Response(response);
        }

        [HttpDelete]
        public IActionResult DeletePersonPhone(int personId, int typePhoneId, string phoneNumber)
        {
            var response = _facadePhone.DeletePersonPhone(personId, typePhoneId, phoneNumber);

            return Response(response);
        }

        [HttpPost]
        public IActionResult SelectPersonPhone(PersonPhone request)
        {
            var response = _facadePhone.SelectPersonPhone(request);

            return Response(response);
        }
    }
}
