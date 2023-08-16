using Risk.Context;

namespace Risk.Services
{
    public static class Database
    {
        public static void RegisterDatabase(this IServiceCollection services)
        {
            services.AddScoped<ApplicationContext>();
        }
    }
}
