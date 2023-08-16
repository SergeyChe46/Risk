using Microsoft.AspNetCore.Mvc;
using Risk.Entities;
using Risk.Entities.ViewModels;
using Risk.Repository;

namespace Risk.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<Employee, EmployeeDto> _repository;
        public EmployeeController(IRepository<Employee, EmployeeDto> repository)
        {
            _repository = repository;
        }

        // GET: Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _repository.GetAll();
            return Ok(employees);
        }

        // GET: Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetEmployee(Guid id)
        {
            var employee = await _repository.GetById(id);
            return employee != null ? Ok(employee) : NotFound(new { id });
        }

        // PUT: Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(Guid id, [FromBody] EmployeeDto employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _repository.Put(id, employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // POST: Employee/
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee([FromBody] EmployeeDto employee)
        {
            try
            {
                await _repository.Post(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return CreatedAtAction(nameof(PostEmployee), new { employee = employee });
        }

        // DELETE: Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            await _repository.Delete(id);
            return Ok(new { id });
        }
    }
}
