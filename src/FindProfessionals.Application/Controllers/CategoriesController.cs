using FindProfessionals.Business.Interfaces.Service;
using FindProfessionals.Domain.Entities;
using FindProfessionals.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindProfessionals.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            return Ok(await categoryService.GetAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<Category>> GetById(Guid id)
        {
            return Ok(await categoryService.GetByIdAsync(id));
        }

        [HttpPost]
        [Route("")]
        //[Authorize(Roles = nameof(UserRole.administrator))]
        public async Task<ActionResult<Category>> Insert(Category model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var address = await categoryService.AddAsync(model);

            return CreatedAtAction(nameof(GetById), new { Id = address.Id }, address);
        }

        [HttpPut]
        [Route("{id:guid}")]
        //[Authorize(Roles = nameof(UserRole.administrator))]
        public async Task<ActionResult<Category>> Update(Category category, Guid id)
        {
            if (category.Id != id)
                return BadRequest();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await categoryService.UpdateAsync(category));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        //[Authorize(Roles = nameof(UserRole.administrator))]
        public async Task<ActionResult<Category>> Delete(Guid id)
        {
            var category = await categoryService.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            if(!await categoryService.RemoveAsync(id))
                return BadRequest(category);

            return NoContent();
        }
    }
}
