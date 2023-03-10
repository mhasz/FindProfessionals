using FindProfessionals.Business.Interfaces.Service;
using FindProfessionals.Domain.Dtos.Address;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindProfessionals.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AdressesController : ControllerBase
    {
        private readonly IAddressService addressService;

        public AdressesController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<AddressDto>> GetById(Guid id)
        {
            return Ok(await addressService.GetByIdAsync(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<AddressDto>> Insert(AddressDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var address = await addressService.AddAsync(model, Guid.Parse(User.Identity.Name));

            return CreatedAtAction(nameof(GetById), new { Id = address.Id } , address);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult<AddressDto>> Update(AddressDto model, Guid id)
        {
            if (model.Id != id)
                return BadRequest();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await addressService.UpdateAsync(model));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var address = await addressService.GetByIdAsync(id);

            if(address == null)
                return NotFound();

            if(!await addressService.RemoveAsync(id))
                return BadRequest(address);

            return NoContent();
        }
    }
}