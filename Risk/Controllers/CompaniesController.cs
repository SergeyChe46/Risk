using Microsoft.AspNetCore.Mvc;
using Risk.Entities;
using Risk.Entities.ViewModels;
using Risk.Repository;


namespace Risk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompaniesRepository _repository;
        public CompaniesController(ICompaniesRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            var companies = await _repository.GetAll();
            return Ok(companies);
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(Guid id)
        {
            var company = await _repository.GetById(id);
            return company != null ? Ok(company) : NotFound(new { id });
        }

        // PUT: api/Companies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(Guid id, [FromBody] CompanyDto company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _repository.PutCompany(id, company);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // POST: api/Companies
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany([FromBody] CompanyDto company)
        {
            try
            {
                await _repository.PostCompany(company);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return CreatedAtAction(nameof(PostCompany), new { company = company });
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            await _repository.DeleteCompany(id);
            return Ok(new { id });
        }
    }
}
