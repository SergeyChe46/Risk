namespace Risk.Services
{
    public static class Cors
    {

        public static void EnableCors(this IServiceCollection services, string policy)
        {
            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }
    }
}
