using Microsoft.AspNetCore.Mvc;
using Risk.Entities;
using Risk.Entities.ViewModels;
using Risk.Repository;

namespace Risk.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IRepository<Company, CompanyDto> _repository;
        public CompanyController(IRepository<Company, CompanyDto> repository)
        {
            _repository = repository;
        }

        // GET: Company
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            var companies = await _repository.GetAll();
            return Ok(companies);
        }

        // GET: Company/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(Guid id)
        {
            var company = await _repository.GetById(id);
            return company != null ? Ok(company) : NotFound(new { id });
        }

        // PUT: Company/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(Guid id, [FromBody] CompanyDto company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _repository.Put(id, company);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // POST: Company
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany([FromBody] CompanyDto company)
        {
            try
            {
                await _repository.Post(company);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return CreatedAtAction(nameof(PostCompany), new { company = company });
        }

        // DELETE: Company/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            await _repository.Delete(id);
            return Ok(new { id });
        }
    }
}
