namespace CleanArchitecture.WebAPI.Extensions
{
    public static class CorsPolicyExtensions
    {
        /// <summary>
        /// Configures the default CORS policy to allow any origin, method, and header.
        /// </summary>
        /// <param name="services">The IServiceCollection to add the CORS policy to.</param>
        public static void ConfigureCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }

        /// <summary>
        /// Configures a named CORS policy with specified options.
        /// </summary>
        /// <param name="services">The IServiceCollection to add the CORS policy to.</param>
        /// <param name="policyName">The name of the CORS policy.</param>
        /// <param name="configurePolicy">A delegate to configure the policy.</param>
        public static void ConfigureNamedCorsPolicy(this IServiceCollection services, string policyName, Action<CorsPolicyBuilder> configurePolicy)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(policyName, configurePolicy);
            });
        }
    }
}
