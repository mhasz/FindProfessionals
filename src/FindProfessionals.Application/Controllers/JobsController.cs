using FindProfessionals.Business.Interfaces.Service;
using FindProfessionals.Domain.Dtos.Job;
using FindProfessionals.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindProfessionals.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : Controller
    {
        private readonly IJobService jobService;

        public JobsController(IJobService jobService)
        {
            this.jobService = jobService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<JobDetails>>> Get()
        {
            return Ok(await jobService.GetAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<JobDetails>> GetById(Guid id)
        {
            return Ok(await jobService.GetByIdAsync(id));
        }

        [HttpPost]
        [Route("")]
        [Authorize()]
        public async Task<ActionResult<JobDetails>> Insert(NewJob newJob)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var job = await jobService.AddAsync(newJob, Guid.Parse(User.Identity.Name));

            return CreatedAtAction(nameof(GetById), new { Id = job.Id }, job);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize()]
        public async Task<ActionResult<JobDetails>> Update(EditJob editJob, Guid id)
        {
            if (editJob.Id != id)
                return BadRequest();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await jobService.UpdateAsync(editJob));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = nameof(UserRole.administrator))]
        public async Task<ActionResult> Delete(Guid id)
        {
            var job = jobService.GetByIdAsync(id);

            if (job == null)
                return NotFound();

            if(!await jobService.RemoveAsync(id))
                return BadRequest();

            return NoContent();
        }
    }
}
