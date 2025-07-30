namespace MovieMateAPI.Dependencies.Configs
{
    public static class CorsConfig
    {
        private const string CorsPolicy = "AllowAll";

        public static void AddCorsServices(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy,
                    builder =>
                    {
                        builder.SetIsOriginAllowed(origin => true)
                               .AllowAnyMethod()
                               .AllowAnyHeader()
                               .AllowCredentials();
                    });
            });
        }

        public static void UseAppCorsConfig(this WebApplication app)
        {
            app.UseCors(CorsPolicy);
        }
    }
}
