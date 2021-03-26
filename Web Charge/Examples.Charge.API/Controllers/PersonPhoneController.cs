using Microsoft.AspNetCore.Mvc;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult InsertPersonPhone(PersonPhoneResponseDto request)
        {
            var response = _facadePhone.InsertPersonPhone(request);

            return Response(response);
        }

        [HttpPut]
        public IActionResult UpdatePersonPhone([FromBody]PersonPhoneResponseDto request, [FromQuery] string newPhoneNumber)
        {
            var response = _facadePhone.UpdatePersonPhone(request, newPhoneNumber);

            return Response(response);
        }

        [HttpDelete]
        public IActionResult DeletePersonPhone([FromQuery] int businessEntityID, [FromQuery] int phoneNumberTypeID, [FromQuery] string phoneNumber)
        {
            var response = _facadePhone.DeletePersonPhone(businessEntityID, phoneNumberTypeID, phoneNumber);

            return Response(response);
        }

        [HttpGet]
        public IActionResult SelectPersonPhone([FromQuery] string phoneNumber)
        {

            var response = _facadePhone.SelectPersonPhone(phoneNumber);

            return Response(response);
        }

        [HttpGet, AllowAnonymous]
        public IActionResult SelectAllPersonPhone()
        {

            var response = _facadePhone.SelectAllPersonPhone();

            return Response(response);
        }
    }
}
