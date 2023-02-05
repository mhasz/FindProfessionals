using FindProfessionals.Business.Interfaces.Service;
using FindProfessionals.Domain.Dtos.User;
using FindProfessionals.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindProfessionals.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("")]
        [Authorize(Roles = nameof(UserRole.administrator))]
        public async Task<ActionResult<IEnumerable<UserDetails>>> Get()
        {
            return Ok(await _userService.GetAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = nameof(UserRole.administrator))]
        public async Task<ActionResult<UserDetails>> GetById(Guid id)
        {
            return Ok(await _userService.GetByIdAsync(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<UserDetails>> Insert(NewUser newUser)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.AddAsync(newUser);
            return CreatedAtAction(nameof(GetById), new { Id = user.Id }, user);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<UserDetails>> Update(Guid id, EditUser user)
        {
            if (id != user.Id)
                return BadRequest();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(await _userService.UpdateAsync(user));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = nameof(UserRole.administrator))]
        public async Task<ActionResult> Delete(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);

            if(user == null)
                return NotFound();

            if(!await _userService.RemoveAsync(id))
                return BadRequest(user);

            return NoContent();
        }

        [HttpGet]
        [Route("login")]
        public async Task<ActionResult> Authenticate(UserLogin userLogin)
        {
            var result = await _userService.ValidateUserAsync(userLogin);

            if (result == null)
                return Unauthorized();

            return Ok(new { token = result });
        } 
    }
}
