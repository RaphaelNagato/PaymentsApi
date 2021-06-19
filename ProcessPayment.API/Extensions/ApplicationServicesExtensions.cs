using Microsoft.Extensions.DependencyInjection;
using ProcessPayment.Core;
using ProcessPayment.Core.Interfaces;
using ProcessPayment.Core.PaymentGateways;
using ProcessPayment.Data;

namespace ProcessPayment.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ICheapPaymentGateway, CheapPaymentGateway>();
            services.AddScoped<IExpensivePaymentGateway, ExpensivePaymentGateway>();
            services.AddScoped<IPremiumPaymentService, PremiumPaymentService>();

            return services;
        }
    }
}
