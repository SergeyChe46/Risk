using Risk.Entities;
using Risk.Entities.ViewModels;
using Risk.Repository;

namespace Risk.Services
{
    public static class Dependencies
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Company, CompanyDto>, CompaniesRepository>();
            services.AddScoped<IRepository<Employee, EmployeeDto>, EmployeesRepository>();
        }
    }
}
