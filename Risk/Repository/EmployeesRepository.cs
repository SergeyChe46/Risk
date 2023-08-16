using Mapster;
using Microsoft.EntityFrameworkCore;
using Risk.Context;
using Risk.Entities;
using Risk.Entities.ViewModels;
using System.Data.Common;

namespace Risk.Repository
{
    public class EmployeesRepository : IRepository<Employee, EmployeeDto>
    {
        private readonly ApplicationContext _context;

        public EmployeesRepository(ApplicationContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task Delete(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Employee?> GetById(Guid id)
        {
            return await _context.Employees
                .Where(emp => emp.Id == id)
                .Include(comp => comp.Company)
                .Select(emp => new Employee
                {
                    Id = id,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Salary = emp.Salary,
                    CompanyId = emp.CompanyId
                })
                .FirstOrDefaultAsync();
        }

        public async Task Post(EmployeeDto entityViewModel)
        {
            var company = await _context.Companies
                .Where(comp => comp.Id == entityViewModel.CompanyId)
                .FirstAsync();
            if (company != null)
            {
                var newEmployee = entityViewModel.Adapt<Employee>();
                company.Employees?.Add(newEmployee);
                _context.Employees.Add(newEmployee);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbException)
                {
                    throw new Exception("Не удалось создать компанию.");
                }
            }
        }

        public async Task Put(Guid id, EmployeeDto entityViewModel)
        {
            var editedEmployee = await _context.Employees.FindAsync(id);
            if (editedEmployee != null)
            {
                editedEmployee.FirstName = entityViewModel.FirstName;
                editedEmployee.LastName = entityViewModel.LastName;
                editedEmployee.Salary = entityViewModel.Salary;
                editedEmployee.CompanyId = entityViewModel.CompanyId;
                _context.Employees.Update(editedEmployee);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw new Exception("Не удалось обновить информацию.");
                }
            }
        }
    }
}
