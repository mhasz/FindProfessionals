using FindProfessionals.Business.Interfaces.Service;
using FindProfessionals.Domain.Entities;
using FindProfessionals.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindProfessionals.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubcategoriesController : Controller
    {
        private readonly ISubcategoryService subcategoryService;

        public SubcategoriesController(ISubcategoryService subcategoryService)
        {
            this.subcategoryService = subcategoryService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Subcategory>>> Get()
        {
            return Ok(await subcategoryService.GetAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<Subcategory>> GetById(Guid id)
        {
            return Ok(await subcategoryService.GetByIdAsync(id));
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = nameof(UserRole.administrator))]
        public async Task<ActionResult<Subcategory>> Insert(Subcategory model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var subcategory = await subcategoryService.AddAsync(model);

            return CreatedAtAction(nameof(GetById), new { Id = subcategory.Id }, subcategory);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = nameof(UserRole.administrator))]
        public async Task<ActionResult<Subcategory>> Update(Subcategory subcategory, Guid id)
        {
            if (subcategory.Id != id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await subcategoryService.UpdateAsync(subcategory));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = nameof(UserRole.administrator))]
        public async Task<ActionResult> Delete(Guid id)
        {
            var subcategory = await subcategoryService.GetByIdAsync(id);

            if (subcategory == null)
                return NotFound();

            if (!await subcategoryService.RemoveAsync(id))
                return BadRequest(subcategory);

            return NoContent();
        }
    }
}
