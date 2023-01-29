﻿using FindProfessionals.Business.Interfaces.Service;
using FindProfessionals.Domain.Dtos.User;
using FindProfessionals.Domain.Entities;
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
        public async Task<ActionResult<IEnumerable<UserDetails>>> Get()
        {
            return Ok(await _userService.GetAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<UserDetails>> GetById(Guid id)
        {
            return Ok(await _userService.GetByIdAsync(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<User>> Insert(NewUser user)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _userService.AddAsync(user))
                return BadRequest(user);

            return CreatedAtAction(nameof(GetById), new { Id = user.Id }, user);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult<User>> Update(Guid id, EditUser user)
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
            var user = await _userService.GetByIdAsync(id);

            if(user == null)
                return NotFound();

            if(!await _userService.RemoveAsync(id))
                return BadRequest(user);

            return Ok();
        }

    }
}