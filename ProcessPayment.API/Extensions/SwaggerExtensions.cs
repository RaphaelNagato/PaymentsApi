using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ProcessPayment.API.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddMySwaggerDoc(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProcessPaymentAPI", Version = "v1" });
            });
            return services;
        }

        public static IApplicationBuilder UseMySwaggerDoc(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProcessPaymentAPI v1"));
            return app;
        }
    }
}
