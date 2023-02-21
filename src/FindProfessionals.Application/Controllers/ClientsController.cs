using FindProfessionals.Business.Interfaces.Service;
using FindProfessionals.Domain.Entities;
using FindProfessionals.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindProfessionals.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        private readonly IClientService clientService;

        public ClientsController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        [Route("")]
        [Authorize(Roles = nameof(UserRole.administrator))]
        public async Task<ActionResult<IEnumerable<Client>>> Get()
        {
            return Ok(await clientService.GetAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = nameof(UserRole.administrator))]
        public async Task<ActionResult<Client>> GetById(Guid id)
        {
            return Ok(await clientService.GetByIdAsync(id));
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<Client>> Insert()
        {
            var client = await clientService.AddAsync(Guid.Parse(User.Identity.Name));

            return CreatedAtAction(nameof(GetById), new { client.Id }, client);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = nameof(UserRole.administrator))]
        public async Task<ActionResult> Delete(Guid id)
        {
            var client = await clientService.GetByIdAsync(id);

            if (client == null)
                return NotFound();

            if(!await clientService.RemoveAsync(id))
                return BadRequest();

            return NoContent();
        }
    }
}