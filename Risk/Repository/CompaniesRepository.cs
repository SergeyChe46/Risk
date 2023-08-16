using Mapster;
using Microsoft.EntityFrameworkCore;
using Risk.Context;
using Risk.Entities;
using Risk.Entities.ViewModels;
using System.Data.Common;

namespace Risk.Repository
{
    public class CompaniesRepository : ICompaniesRepository
    {
        private readonly ApplicationContext _context;
        public CompaniesRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company?> GetById(Guid id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task PutCompany(Guid id, CompanyDto editedData)
        {
            var editedCompany = await _context.Companies.FindAsync(id);
            if (editedCompany != null)
            {
                editedCompany.Name = editedData.Name;
                editedCompany.City = editedData.City;
                editedCompany.Phone = editedData.Phone;
                _context.Companies.Update(editedCompany);
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

        public async Task PostCompany(CompanyDto newEntityData)
        {
            var newCompany = newEntityData.Adapt<Company>();
            _context.Companies.Add(newCompany);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbException)
            {
                throw new Exception("Не удалось создать компанию.");
            }
        }

        public async Task DeleteCompany(Guid id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company != null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
            }
        }
    }
}
