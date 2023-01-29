using FindProfessionals.Business.Interfaces.Repository;
using FindProfessionals.Business.Interfaces.Service;
using FindProfessionals.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindProfessionals.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UsersController(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return Ok(await _userRepository.GetUsersAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<User>> GetById(Guid id)
        {
            return Ok(await _userRepository.GetUserByIdAsync(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<User>> Insert(User user)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _userService.AddAsync(user))
                return BadRequest(user);

            return CreatedAtAction(nameof(GetById), new { Id = user.Id }, user);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult<User>> Update(Guid id, User user)
        {
            if (id != user.Id)
                return BadRequest();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _userService.UpdateAsync(user))
                return BadRequest(user);

            return Ok(user);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            if(user == null)
                return NotFound();

            if(!await _userService.RemoveAsync(id))
                return BadRequest(user);

            return Ok(user);
        }

    }
}
