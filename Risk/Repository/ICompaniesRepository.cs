using Risk.Entities;
using Risk.Entities.ViewModels;

namespace Risk.Repository
{
    public interface ICompaniesRepository
    {
        Task DeleteCompany(Guid id);
        Task<IEnumerable<Company>> GetAll();
        Task<Company?> GetById(Guid id);
        Task PostCompany(CompanyDto company);
        Task PutCompany(Guid id, CompanyDto company);
    }
}