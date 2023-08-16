using Risk.Repository;

namespace Risk.Services
{
    public static class Dependencies
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICompaniesRepository, CompaniesRepository>();
        }
    }
}
